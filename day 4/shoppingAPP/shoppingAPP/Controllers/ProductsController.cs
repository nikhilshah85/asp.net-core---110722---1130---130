using Microsoft.AspNetCore.Mvc;
using shoppingAPP.Models;
namespace shoppingAPP.Controllers
{
    public class ProductsController : Controller
    {
        Products pObj = new Products();

        public IActionResult DisplayProducts()
        {
            ViewBag.products = pObj.GetAllProducts();
            return View();
        }
                
        public IActionResult SearchProduct()
        {
            ViewBag.hasData = false;
            ViewBag.errMessage = "";
            return View();
        }

        [HttpPost]
        public IActionResult SearchProduct(int productId)
        {   
            try
            {
                ViewBag.productinfo = pObj.GetProductById(productId);
                ViewBag.hasData = true;
            }
            catch(Exception es)
            {
                ViewBag.errMessage = es.Message;
            }          
          
            return View();
        }


        [HttpGet]
        public IActionResult DeleteProduct()
        {
            ViewBag.deleteMessage = "";
            return View();
        }
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            ViewBag.deleteMessage = pObj.DeleteProduct(productId);
            return View();
        }


        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Products newP)
        {
            ViewBag.addProductMessage = pObj.AddProduct(newP);
            return View();
        }
    }
}
