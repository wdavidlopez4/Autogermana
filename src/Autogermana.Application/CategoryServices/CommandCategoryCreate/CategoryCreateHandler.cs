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

namespace Autogermana.Application.CategoryServices.CommandCategoryCreate
{
    public class CategoryCreateHandler : IRequestHandler<CategoryCreateCommand, CategoryCreateDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public CategoryCreateHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
            this.factory = factory;
        }

        public async Task<CategoryCreateDTO> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            Category category;

            if (request is null)
                throw new ArgumentNullException("peticion nula");

            //fabricamos
            category = (Category) this.factory.BuilderCategory(
                nombre: request.Nombre,
                descripcion: request.Descripcion,
                estado: request.Estado);

            //guardamos
            category = await this.repository.Save<Category>(category, cancellationToken);
            if(category is null)
                throw new Exception("no se pudo guardar");

            //mapeamos y retornamos
            return this.autoMapping.Map<Category, CategoryCreateDTO>(category);
        }
    }
}
