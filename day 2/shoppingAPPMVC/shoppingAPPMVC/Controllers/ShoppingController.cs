using Microsoft.AspNetCore.Mvc;

namespace shoppingAPPMVC.Controllers
{
    public class ShoppingController : Controller
    {
      public IActionResult Productlist()
        {
            //this data will usually come from model, (model decides where it comes from)
            List<string> pList = new List<string>()
            {
                "Cold-Drinks",
                "Electronics",
                "Cloths",
                "Shoes",
                "Accessories",
                "Eateries"
            };

            ViewBag.products = pList;
            ViewBag.totalProducts = pList.Count;
            return View();
        }

        public IActionResult SearchProduct()
        {
            return View();
        }

        public IActionResult productSale()
        {
            return View();
        }
    }
}
