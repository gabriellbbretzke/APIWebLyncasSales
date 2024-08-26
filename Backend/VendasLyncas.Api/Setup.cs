using MediatR;
using Microsoft.EntityFrameworkCore;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.Context.Context;
using VendasLyncas.Infra.Context.Repositories;
using VendasLyncas.Infra.Data.Repositories;

namespace VendasLyncas.Api
{
    public static class Setup
    {
        //public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        //{
        //    services.AddDbContext<ApplicationContext>(options =>
        //    {
        //        options.UseSqlServer(connectionString);
        //    });
        //}

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryCliente, RepositoryCliente>();
            services.AddTransient<IRepositoryVenda, RepositoryVenda>();
        }

        public static void ConfigureMediator(this IServiceCollection services)
        {
            var assemblyDomain = AppDomain.CurrentDomain.Load("VendasLyncas.Domain");
            services.AddMediatR(assemblyDomain);
        }
    }
}
