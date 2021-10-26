using Autogermana.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Infrastructure.EFCore
{
    public class AutogermanaContext : DbContext
    {
        public DbSet<Product> ImageMonitorings { get; set; }

        public DbSet<Category> ManualMonitorings { get; set; }


        public AutogermanaContext(DbContextOptions<AutogermanaContext> options) : base(options)
        {

        }
    }
}
