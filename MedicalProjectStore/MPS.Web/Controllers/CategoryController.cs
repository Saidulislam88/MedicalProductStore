using MPS.Entities;
using MPS.Services;
using MPS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPS.Web.Controllers
{
    public class CategoryController : Controller
    {

        CategoriesService categoryService = new CategoriesService();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();

            model.Categories = categoryService.GetCategories();

            if (!string.IsNullOrEmpty(search))
            {
                model.SearchTerm = search;

                model.Categories = model.Categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView("CategoryTable", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewCategoryViewModel model = new NewCategoryViewModel();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            var newCategory = new Category();
            newCategory.Name = model.Name;
            newCategory.description = model.Description;
            newCategory.ImageURL = model.ImageURL;

            categoryService.SaveCategory(newCategory);

            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            var category = categoryService.GetCategory(ID);
            model.ID = category.ID;
            model.Name = category.Name;
            model.Description = category.description;
            model.ImageURL = category.ImageURL;
           
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var existingCategory = categoryService.GetCategory(model.ID);
            existingCategory.Name = model.Name;
            existingCategory.description = model.Description;
            existingCategory.ImageURL = model.ImageURL;

            categoryService.UpdateCategory(existingCategory);
            return RedirectToAction("CategoryTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {

            categoryService.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
        }
    }
}