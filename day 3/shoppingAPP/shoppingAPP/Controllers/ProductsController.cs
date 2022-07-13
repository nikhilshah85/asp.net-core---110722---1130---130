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
            return View();
        }

        [HttpPost]
        public IActionResult SearchProduct(int productId)
        {   
            ViewBag.hasData = true;
            ViewBag.productinfo = pObj.GetProductById(productId);
            return View();
        }



    }
}
