﻿using MPS.Database;
using MPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MPS.Services
{
    public class ProductsService
    {
        public Product GetProduct(int ID)
        {
            using (var context = new MPSContext())
            {
                return context.Products.Where(x => x.ID == ID).Include(x => x.Category).FirstOrDefault();
            }

        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new MPSContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();
            }
        }
        public List<Product> GetProducts()
        {
            using (var context = new MPSContext())
            {
                return context.Products.Include(x=>x.Category).ToList();
            }

        }

        public void SaveProduct(Product product)
        {
            using (var context =new MPSContext() )
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
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
