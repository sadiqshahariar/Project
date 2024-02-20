using FirstWebProject.Repositories.Interface;
using FirstWebProject.Repositories.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace FirstWebProject.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection DIService(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            return services;
        }
    }
}
