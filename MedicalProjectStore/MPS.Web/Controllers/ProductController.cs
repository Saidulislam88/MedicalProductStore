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
    public class ProductController : Controller
    {
        ProductsService productService = new ProductsService();
        CategoriesService categoryService = new CategoriesService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search)
        {
            ProductSearchViewModel model = new ProductSearchViewModel();

            model.Products = productService.GetProducts();

            if (string.IsNullOrEmpty(search) == false)
            {
                model.SearchTerm = search;
                model.Products = model.Products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

          
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();

            model.AvailableCategories = categoryService.GetCategories();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            CategoriesService categoryService = new CategoriesService();

            var NewProduct = new Product();

            NewProduct.Name = model.Name;
            NewProduct.description = model.Description;
            NewProduct.Price = model.Price;
            NewProduct.Category = categoryService.GetCategory(model.CategoryID);




            productService.SaveProduct(NewProduct);

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();
            var product = productService.GetProduct(ID);
            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.description;
            model.Price = product.Price;
            model.CategoryID = product.Category != null ? product.Category.ID : 0;

            model.AvailableCategories = categoryService.GetCategories();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = productService.GetProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.description = model.Description;
            existingProduct.Price = model.Price;
            existingProduct.Category = categoryService.GetCategory(model.CategoryID);

            productService.UpdateProduct(existingProduct);

            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productService.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }
    }
}