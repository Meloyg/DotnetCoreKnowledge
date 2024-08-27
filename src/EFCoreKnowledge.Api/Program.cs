using EFCoreKnowledge.Api;
using EFCoreKnowledge.Api.Interceptors;
using EFCoreKnowledge.Api.Requests;
using EFCoreKnowledge.Api.Services;
using EFCoreKnowledge.Entities.Models;
using EFCoreKnowledge.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton(TimeProvider.System)
    .AddSingleton<IEmailService, EmailService>()
    .AddScoped<ConnectionInterceptor>()
    .AddScoped<TransactionInterceptor>()
    .AddScoped<AuditableEntitiesInterceptor>()
    .AddScoped<ValidateEntitiesStateInterceptor>();

builder.Services.AddDbContext<RepositoryContext>((sp, opts) =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            options => options.MigrationsAssembly("EFCoreKnowledge.Api"))
        .AddInterceptors(
            sp.GetRequiredService<ConnectionInterceptor>(),
            sp.GetRequiredService<TransactionInterceptor>(),
            sp.GetRequiredService<AuditableEntitiesInterceptor>(),
            sp.GetRequiredService<ValidateEntitiesStateInterceptor>()
        );
}, contextLifetime: ServiceLifetime.Scoped);


var app = builder.Build();

app.UseHttpsRedirection();
app.MigrateDatabase();

app.MapPost("/register-user", async (AddUserRequest addUserRequest,
    IEmailService emailService,
    RepositoryContext dbContext,
    CancellationToken cancellationToken) =>
{
    var user = new User { Name = addUserRequest.Name, Email = addUserRequest.Email };
    using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
    try
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);
        var emailSent = await emailService.SendWelcomeEmailAsync(user.Id, user.Name, user.Email);
        if (!emailSent)
            throw new Exception("Failed to send welcome email");
        await transaction.CommitAsync(cancellationToken);
        return Results.Ok();
    }
    catch (Exception)
    {
        await transaction.RollbackAsync(cancellationToken);
        return Results.Problem(detail: "Registration failed!", statusCode: StatusCodes.Status500InternalServerError);
    }
});

app.Run();