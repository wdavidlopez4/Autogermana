using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Application.CategoryServices.QueryAllCategories
{
    public class AllCategoriesQuery : IRequest<List<AllCategoriesDTO>>
    {

    }
}
