using Autogermana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Domain.Factories
{
    public class Factory : IFactory
    {
        public Entity BuilderCategory(string nombre, string descripcion, StateCategoryEnum estado, Guid? id = null)
        {
            return new Category(nombre, descripcion, estado, id);
        }

        public Entity BuilderProduct(string codigo, string nombre, float precio, int stock, string descripcion, 
            byte imagen, StateProductEnum estado, Category category, string categoryId, Guid? id = null)
        {
            return new Product(codigo, nombre, precio, stock, descripcion, imagen, estado, category, categoryId, id);
        }
    }
}
