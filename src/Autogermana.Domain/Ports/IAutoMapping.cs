using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Domain.Ports
{
    public interface IAutoMapping
    {
        public TDestination Map<TSource, TDestination>(TSource source);
    }
}
