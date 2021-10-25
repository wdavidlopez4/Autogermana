using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Domain.Entities
{
    public class Category : Entity
    {
        public string Nombre { get; private set; }

        public string Descripcion { get; private set; }

        public StateCategoryEnum Estado { get; private set; }

        public List<Product> Products { get; private set; }

        /// <summary>
        /// for ef
        /// </summary>
        public Category():base()
        {

        }

        /// <summary>
        /// contructor para crear la categoria sin produtos
        /// </summary>
        internal Category(string nombre, string descripcion, StateCategoryEnum estado, Guid? id = null): base(id)
        {
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.Nombre = nombre;

            //validaciones
        }
    }
}
