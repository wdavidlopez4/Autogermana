using Autogermana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Domain.Factories
{
    public interface IFactory
    {
        public Entity BuilderCategory(string nombre, string descripcion, StateCategoryEnum estado, Guid? id = null);

        public Entity BuilderProduct(string codigo, string nombre, float precio, int stock, string descripcion, Byte imagen,
            StateProductEnum estado, string categoryId, Guid? id = null);
    }
}
