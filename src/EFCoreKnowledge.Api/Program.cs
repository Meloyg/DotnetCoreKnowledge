using EFCoreKnowledge.Api;
using EFCoreKnowledge.Api.Interceptors;
using EFCoreKnowledge.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
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

app.Run();