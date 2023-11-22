using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineProductStore.Server.Data;
using OnlineProductStore.Server.Services;
using OnlineProductStore.Shared.Settings;
using System.Text;

namespace OnlineProductStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "BlazorCors",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5187")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection(nameof(TokenSettings)));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var tokenSettings = builder.Configuration.GetSection(nameof(TokenSettings)).Get<TokenSettings>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = tokenSettings.Issuer,

                        ValidateAudience = true,
                        ValidAudience = tokenSettings.Audience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.SecretKey)),

                        ClockSkew = TimeSpan.Zero
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //
            app.UseHttpsRedirection();
            app.UseCors("BlazorCors");
            app.UseAuthorization();
            //

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }

        private static void RegisterAuthServices(WebApplicationBuilder builder)
        {
           
        }
    }
}