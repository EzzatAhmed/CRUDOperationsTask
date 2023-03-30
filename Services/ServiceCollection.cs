using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IReposetory;
using ApplicationInfrastructure;
using ApplicationInfrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Services.BusinessConcrete;
using Services.BusinessInterface;

namespace Services
{
    public static class ServiceCollection
    {
        public static void ServiceLibrary(this IServiceCollection services) 
        {
            services.AddTransient<IEmployeeRepo,EmployeeRepo>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}