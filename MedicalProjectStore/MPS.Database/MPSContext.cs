using MPS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Database
{
    public class MPSContext : DbContext,IDisposable
    {
        public MPSContext() : base("MPSConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
