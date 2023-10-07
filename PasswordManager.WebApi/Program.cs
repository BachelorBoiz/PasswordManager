using Microsoft.EntityFrameworkCore;
using PasswordManager.Core.IServices;
using PasswordManager.Domain.IRepositories;
using PasswordManager.Domain.Services;
using PasswordManager.Infrastructure;
using PasswordManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

// Dependency Injection for PasswordEntry
builder.Services.AddScoped<IPasswordEntryService, PasswordEntryService>();

builder.Services.AddDbContext<PasswordManagerDbContext>(options => 
    options.UseSqlite("Data Source=/data/passwords.db"));

builder.Services.AddScoped<IPasswordEntryRepository, PasswordEntryRepository>();

builder.Services.AddCors(options => options
    .AddPolicy("dev-policy", policyBuilder =>
        policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

using (var scope = app.Services.CreateAsyncScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PasswordManagerDbContext>();
    ctx.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("dev-policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
