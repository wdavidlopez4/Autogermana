using Autogermana.Domain.Entities;
using Autogermana.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autogermana.Application.ProductServices.QueryProductsByCategory
{
    public class ProductsByCategoryHandler : IRequestHandler<ProductsByCategoryQuery, List<ProductsByCategoryDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public ProductsByCategoryHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<ProductsByCategoryDTO>> Handle(ProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Product> products;

            if (request is null)
                throw new ArgumentNullException("peticion nula");

            //recuperamos la lista segun el id de la categoria
            products = await this.repository.GetAll<Product>(x => x.CategoryId == request.CategoryId, cancellationToken);
            if (products is null)
                throw new Exception("no se pudo recuperar los productos");

            //mapeamos y retornamos
            return this.autoMapping.Map<List<Product>, List<ProductsByCategoryDTO>>(products);
        }
    }
}
