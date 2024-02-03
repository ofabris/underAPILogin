using Microsoft.EntityFrameworkCore;
using UnderAPILogin.Data;
using UnderAPILogin.Repositories;
using UnderAPILogin.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRegisterUserRepository, RegisterUserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();
builder.Services.AddScoped<IDeleteUserRepository, DeleteUserRepository>();
builder.Services.AddScoped<IInsertMusicRepository, InsertMusicRepository>();
builder.Services.AddScoped<IInsertMusicService, InsertMusicService>();
builder.Services.AddScoped<ITokenService>(provider => new TokenService("+rEEa6vGT2R3zkudeQrXXpwvFtaTSjBFBQiBbBwt9eI=", "Under"));

var app = builder.Build();

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
 