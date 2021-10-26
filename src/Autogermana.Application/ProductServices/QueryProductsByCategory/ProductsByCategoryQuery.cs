using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Application.ProductServices.QueryProductsByCategory
{
    public class ProductsByCategoryQuery : IRequest<List<ProductsByCategoryDTO>>
    {
        public string CategoryId { get; private set; }
    }
}
