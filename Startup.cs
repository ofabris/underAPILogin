using Microsoft.EntityFrameworkCore;
using UnderAPILogin.Data;
using UnderAPILogin.Repositories;
using UnderAPILogin.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace UnderAPILogin
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes("+rEEa6vGT2R3zkudeQrXXpwvFtaTSjBFBQiBbBwt9eI=");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "Under",
                        ValidAudience = "Under",
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                    };
                });

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 23))));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IRegisterUserRepository, RegisterUserRepository>();
            services.AddScoped<IDeleteUserService, DeleteUserService>();

            services.AddOptions<TokenServiceOptions>().Bind(Configuration.GetSection("TokenService")).ValidateDataAnnotations();

            services.AddScoped<ITokenService>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<TokenServiceOptions>>().Value;
                return new TokenService(options.Secret, options.Issuer);
            });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
