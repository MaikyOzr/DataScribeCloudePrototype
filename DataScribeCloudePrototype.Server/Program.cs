using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Repositories;
using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DataScribeCloudePrototype.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            var service = builder.Services;

            // Add services to the container.

            service.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            service.AddDbContext<ApplicationDbContext>(
                opt => opt.UseSqlServer
                (builder.Configuration.GetConnectionString("DefaultConnection")));



            service.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://localhost:5173")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            service.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
            service.AddScoped<JWTProvider>();
            service.AddHttpContextAccessor();
            service.AddScoped<UserManager>();
            service.AddScoped<FileFactory>();
            service.AddScoped<FileStorageManager>();
            service.AddScoped<GoogleService>();
            service.AddResponseCaching();
            service.AddControllers(options =>
            {
                options.CacheProfiles.Add("Default30",
                    new CacheProfile()
                    {
                        Duration = 30
                    });
            });

            var app = builder.Build();

            app.UseCors();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseResponseCaching();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
