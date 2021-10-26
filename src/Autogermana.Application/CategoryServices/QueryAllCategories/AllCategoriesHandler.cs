using Autogermana.Domain.Entities;
using Autogermana.Domain.Factories;
using Autogermana.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autogermana.Application.CategoryServices.QueryAllCategories
{
    public class AllCategoriesHandler : IRequestHandler<AllCategoriesQuery, List<AllCategoriesDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public AllCategoriesHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<AllCategoriesDTO>> Handle(AllCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> categorias;

            if (request is null)
                throw new ArgumentNullException("peticion nula");

            //obtenemos
            categorias = await this.repository.GetAll<Category>(cancellationToken);
            if (categorias is null)
                throw new Exception("no se retuperaron las categorias");

            //mapeamos y retornamos
            return this.autoMapping.Map<List<Category>, List<AllCategoriesDTO>>(categorias);
        }
    }
}
