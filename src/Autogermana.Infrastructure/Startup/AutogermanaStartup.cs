using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autogermana.Application.CategoryServices.CommandCategoryCreate;
using Autogermana.Application.CategoryServices.QueryAllCategories;
using Autogermana.Application.ProductServices.CommandProductCreate;
using Autogermana.Application.ProductServices.CommandProductUpdateData;
using Autogermana.Application.ProductServices.QueryProductsByCategory;
using Autogermana.Infrastructure.EFCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; //getConnectionString
using Microsoft.Extensions.DependencyInjection;

namespace Autogermana.Infrastructure.Startup
{
    public class AutogermanaStartup
    {
        public static void SetUp(IServiceCollection services, IConfiguration configuration)
        {
            InyectionContainer.Inyection(services);
            ConfigurationSqlServer(services, configuration);
            ConfigurarMapper(services);
            ConfigurarMediador(services);
        }

        /// <summary>
        /// configura el sql server
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void ConfigurationSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            // entity framework db context
            string connString = configuration.GetConnectionString("AutogemanaConnectionString"); //obtenemos la cadena de coneccion DESDE EL ARCHIVO APPSETTINGS
            services.AddDbContext<AutogermanaContext>(
                options => options.UseSqlServer(connString));
        }

        /// <summary>
        /// configura el mapeo del sistema dto-entitdades de modelo
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigurarMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// configura el patron mediator controladores- servicios
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigurarMediador(IServiceCollection services)
        {
            services.AddMediatR(typeof(ProductsByCategoryQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ProductUpdateDataCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ProductCreateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AllCategoriesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CategoryCreateCommand).GetTypeInfo().Assembly);
        }
    }
}
