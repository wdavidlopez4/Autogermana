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

namespace Autogermana.Application.ProductServices.CommandProductUpdateData
{
    public class ProductUpdateDataHandler :IRequestHandler<ProductUpdateDataCommand, ProductUpdateDataDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public ProductUpdateDataHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
            this.factory = factory;
        }

        public async Task<ProductUpdateDataDTO> Handle(ProductUpdateDataCommand request, CancellationToken cancellationToken)
        {
            Product product;

            if (repository is null)
                throw new ArgumentNullException("peticion nula");

            //fabricar para actualizar el producto
            product = (Product)this.factory.BuilderProduct(
                codigo: request.Codigo,
                nombre: request.Nombre,
                precio: request.Precio,
                stock: request.Stock,
                descripcion: request.Descripcion,
                imagen: request.Imagen,
                estado: request.Estado,
                categoryId: request.CategoryId,
                id: Guid.Parse(request.Id));

            //actualizar
            product = await this.repository.Update<Product>(product, cancellationToken);
            if (product is null)
                throw new Exception("no se pudo actualizar");

            //mapeamos y retornamos 
            return this.autoMapping.Map<Product, ProductUpdateDataDTO>(product);
        }
    }
}
