using AdminPanel.BLL.Interfaces;
using AdminPanel.BLL.Services;
using AdminPanel.DAL.Repositories.Implements;
using AdminPanel.DAL.Repositories.Interfaces;
using AdminPanel.Domain.Entities;
using AdminPanel.HostedServices;

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
            webApplicationBuilder.Services.AddScoped<IAccountService, AccountService>();
        }

        public static void AddHostedService(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddHostedService<CheckDBHostedService>();
        }
    }
}
