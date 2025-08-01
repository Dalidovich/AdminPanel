using AdminPanel.DAL;
using AdminPanel.Domain.Enums;
using AdminPanel.Midlaware;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.AddRepositores();
            builder.AddServices();
            builder.AddHostedService();
            builder.AddJWT();
            builder.Services.AddDbContext<AppDBContext>(opt => opt.UseNpgsql(
                builder.Configuration.GetConnectionString(StandartConst.NameConnection)));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(StandartConst.CorsPolicyName,
                    CorsBuilder => CorsBuilder
                        .WithOrigins($"{builder.Configuration.GetSection("CorsSettings:URL").Value}")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        );
            });

            var app = builder.Build();

            app.UseCors(builder.Configuration.GetSection("CorsSettings:CorsPolicyName").Value);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
