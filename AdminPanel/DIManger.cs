using AdminPanel.DAL.Repositories.Implements;
using AdminPanel.DAL.Repositories.Interfaces;
using AdminPanel.Domain.Entities;

namespace AdminPanel
{
    public static class DIManger
    {
        public static void AddRepositores(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<IRepository<Account>, AccountRepository>();
        }

        public static void AddServices(this WebApplicationBuilder webApplicationBuilder)
        {

        }

        public static void AddHostedService(this WebApplicationBuilder webApplicationBuilder)
        {

        }

        public static void AddMiddleware(this WebApplication webApplication)
        {

        }
    }
}
