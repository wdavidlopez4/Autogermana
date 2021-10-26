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

namespace Autogermana.Application.ProductServices.CommandProductCreate
{
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, ProductCreateDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public ProductCreateHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
            this.factory = factory;
        }

        public async Task<ProductCreateDTO> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            Product product;

            if (request is null)
                throw new ArgumentNullException("peticion nula");

            //fabricar
            product = (Product)this.factory.BuilderProduct(
                codigo: request.Codigo,
                nombre: request.Nombre,
                precio: request.Precio,
                stock: request.Stock,
                descripcion: request.Descripcion,
                imagen: request.Imagen,
                estado: request.Estado,
                categoryId: request.CategoryId);

            //guardar
            product = await this.repository.Save<Product>(product, cancellationToken);

            //mapear y retornar
            return this.autoMapping.Map<Product, ProductCreateDTO>(product);

        }
    }
}
