using UnderAPILogin.Models;
using UnderAPILogin.Repositories;
using UnderAPILogin.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicione o caminho do arquivo como uma configuração
var configuration = builder.Configuration;
var filePath = configuration.GetValue<string>("UserRepository:FilePath");

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository>(provider => new UserRepository(filePath));
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRegisterUserRepository>(provider => new RegisterUserRepository(filePath));
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure o pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
