using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Entities
{
    public class Product : BaseEntities
    {
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }
    }
}
