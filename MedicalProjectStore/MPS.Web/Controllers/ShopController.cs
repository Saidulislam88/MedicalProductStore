using MPS.Services;
using MPS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPS.Web.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        ProductsService productsService = new ProductsService();

        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();

            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null)
            {
                //var productIDs = CartProductsCookie.Value;
                //var ids = productIDs.Split('-');
                //List<int> pIDs = ids.Select(x => int.Parse(x)).ToList();

                 
                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();


                model.CartProducts = productsService.GetProducts(model.CartProductIDs);
            }

            return View(model);
        }


    }
}