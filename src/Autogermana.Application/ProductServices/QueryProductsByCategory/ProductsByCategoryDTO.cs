using Autogermana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Application.ProductServices.QueryProductsByCategory
{
    public class ProductsByCategoryDTO
    {
        public string Id { get; set; }
        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public float Precio { get; set; }

        public int Stock { get; set; }

        public string Descripcion { get; set; }

        public Byte Imagen { get; set; }

        public StateProductEnum Estado { get; set; }

        public string CategoryId { get; set; }
    }
}
