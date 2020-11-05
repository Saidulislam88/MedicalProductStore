using MPS.Database;
using MPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Services
{
    public class ProductsService
    {
        public Product GetProduct(int ID)
        {
            using (var context = new MPSContext())
            {
                return context.Products.Find(ID);
            }

        }

        public List<Product> GetProducts()
        {
            using (var context = new MPSContext())
            {
                return context.Products.ToList();
            }

        }

        public void SaveProduct(Product product)
        {
            using (var context =new MPSContext() )
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

        }

        public void UpdateProduct(Product product)
        {
            using (var context = new MPSContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }


        }

        public void DeleteProduct(int ID)
        {
            using (var context = new MPSContext())
            {
                var product = context.Products.Find(ID);

                context.Products.Remove(product);
                context.SaveChanges();
            }


        }
    }
}
