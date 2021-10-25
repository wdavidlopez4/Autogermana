using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Domain.Entities
{
    public class Product : Entity
    {
        public string Codigo { get; private set; }

        public string Nombre { get; private set; }

        public float Precio { get; private set; }

        public int Stock { get; private set; }
        
        public string Descripcion { get; private set; }
        
        public Byte Imagen { get; private set; }

        public StateProductEnum Estado { get; private set; }

        public Category Category { get; private set; }

        public string CategoryId { get; private set; }

        /// <summary>
        /// for ef
        /// </summary>
        private Product()
        {

        }

        /// <summary>
        /// creacion del producto
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="descripcion"></param>
        /// <param name="imagen"></param>
        /// <param name="estado"></param>
        /// <param name="category"></param>
        /// <param name="categoryId"></param>
        /// <param name="id"></param>
        internal Product(string codigo, string nombre, float precio, int stock, string descripcion, Byte imagen, 
            StateProductEnum estado, Category category, string categoryId, Guid? id = null):base(id)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Stock = stock;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Estado = estado;
            this.Category = category;
            this.CategoryId = categoryId;

            //validaciones
        }
    }
}
