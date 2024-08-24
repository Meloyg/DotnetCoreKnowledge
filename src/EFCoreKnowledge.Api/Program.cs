using EFCoreKnowledge.Api;
using EFCoreKnowledge.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RepositoryContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        options => options.MigrationsAssembly("EFCoreKnowledge.Api")));

var app = builder.Build();

app.UseHttpsRedirection();
app.MigrateDatabase();

app.Run();