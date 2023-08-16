using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInformationDemo.Models;

namespace ProductInformationDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _db;

        public ProductController(ProductDbContext db)
        {
            _db = db;
        }

        public IActionResult ProductList()
        {
            var productList = _db.ProductMsts.ToList();
            return View(productList);
           
        }

        public IActionResult ProductDetail(int id)
        {
            var productDetail = _db.ProductMsts.FirstOrDefault(x => x.ProductId == id);
            if (productDetail != null)
            {
                return View(productDetail);
            }
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductMst product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productAdd = new ProductMst()
                    {
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        ProductPrice = product.ProductPrice,
                        OpeningStock = product.OpeningStock,
                        BuyStock = product.BuyStock,
                        ClosingStock = (product.OpeningStock + product.BuyStock),

                    };
                    _db.ProductMsts.Add(productAdd);
                    _db.SaveChanges();
                    return RedirectToAction("ProductList");
                }
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            try
            {
                var productDetail = _db.ProductMsts.FirstOrDefault(x => x.ProductId == id);
                if (productDetail != null)
                {
                    return View(productDetail);
                }
                return RedirectToAction("ProductList");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductMst product)
        {
            var productUpdate = _db.ProductMsts.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (productUpdate != null)
            {
                productUpdate.ProductName = product.ProductName;
                productUpdate.ProductDescription = product.ProductDescription;
                productUpdate.ProductPrice = product.ProductPrice;
                productUpdate.OpeningStock = product.OpeningStock;
                productUpdate.BuyStock = product.BuyStock;
                productUpdate.SellStock = product.SellStock;

                if(productUpdate.SellStock <= productUpdate.BuyStock)
                {
                    productUpdate.ClosingStock = (productUpdate.OpeningStock - productUpdate.BuyStock);
                }

                //if()
                //{

                //}
               

                _db.Entry(productUpdate).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View();
            
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var productDetail = _db.ProductMsts.FirstOrDefault(x => x.ProductId == id);
                if (productDetail != null)
                {
                    return View(productDetail);
                }
                return RedirectToAction("ProductList");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteProduct(ProductMst product)
        {
            try
            {
                var productDelete = _db.ProductMsts.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (productDelete != null)
                {
                    _db.ProductMsts.Remove(productDelete);
                    _db.SaveChanges();
                    return RedirectToAction("ProductList");
                }
                return View();
            }

            catch (Exception)
            {
                return View("Error");
            } 
            
        }
    }
}
