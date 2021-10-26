using Autogermana.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Application.CategoryServices.CommandCategoryCreate
{
    public class CategoryCreateCommand : IRequest<CategoryCreateDTO>
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public StateCategoryEnum Estado { get; set; }
    }
}
