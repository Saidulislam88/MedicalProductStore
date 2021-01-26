using MPS.Database;
using MPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MPS.Services
{
    public class CategoriesService
    {
        public Category GetCategory(int ID)
        {
            using (var context = new MPSContext())
            {
                return context.Categories.Find(ID);
            }

        }

        public List<Category> GetCategories()
        {
            using (var context = new MPSContext())
            {
                return context.Categories.Include(x => x.Products).ToList();
            }

        }

        public void SaveCategory(Category category)
        {
            using (var context =new MPSContext() )
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }

        }

        public void UpdateCategory(Category category)
        {
            using (var context = new MPSContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }


        }

        public void DeleteCategory(int ID)
        {
            using (var context = new MPSContext())
            {
                var category = context.Categories.Find(ID);

                context.Categories.Remove(category);
                context.SaveChanges();
            }


        }
    }
}
