using Autogermana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Application.CategoryServices.QueryAllCategories
{
    public class AllCategoriesDTO
    {
        public string ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public StateCategoryEnum Estado { get; set; }
    }
}
