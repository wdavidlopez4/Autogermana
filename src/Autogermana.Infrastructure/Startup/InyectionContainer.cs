using Autogermana.Domain.Factories;
using Autogermana.Domain.Ports;
using Autogermana.Infrastructure.Mapping;
using Autogermana.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Infrastructure.Startup
{
    public class InyectionContainer
    {
        public static void Inyection(IServiceCollection services)
        {
            services.AddScoped<IRepository, RepositorySQL>();
            services.AddScoped<IAutoMapping, AutoMapping>();
            services.AddScoped<IFactory, Factory>();
        }
    }
}
