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
            try
            {
                var productDetail = _db.ProductMsts.FirstOrDefault(x => x.ProductId == id);
                if (productDetail != null)
                {
                    return View(productDetail);
                }
                return RedirectToAction("ProductList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
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

                    if (_db.ProductMsts.Where(u => u.ProductName == product.ProductName /*|| u.ProductDescription == product.ProductDescription*/).Any())
                    {
                        TempData["ErrorMessage"] = "ProductName already exists.";
                        return View();
                    }

                    else
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
                        //if (productAdd.BuyStock <= productAdd.OpeningStock)
                        //{
                        _db.ProductMsts.Add(productAdd);
                        _db.SaveChanges();
                        return RedirectToAction("ProductList");
                        //}
                        //else
                        //{
                        //    TempData["ErrorMessage"] = "Buy stock  must be less or equal to the opening stock";
                        //    return View();
                        //}
                    }

                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductMst product)
        {
            try
            {
                var productUpdate = _db.ProductMsts.FirstOrDefault(x => x.ProductId == product.ProductId);

                if (productUpdate != null)
                {
                    productUpdate.ProductId = product.ProductId;
                    productUpdate.ProductName = product.ProductName;
                    productUpdate.ProductDescription = product.ProductDescription;
                    productUpdate.ProductPrice = product.ProductPrice;
                    productUpdate.OpeningStock = product.OpeningStock;
                    productUpdate.BuyStock = product.BuyStock;
                    productUpdate.SellStock = product.SellStock;

                    var closingStock = productUpdate.OpeningStock + productUpdate.BuyStock;

                    if (productUpdate.SellStock <= closingStock)
                    {
                        productUpdate.ClosingStock = ((productUpdate.OpeningStock + productUpdate.BuyStock) - productUpdate.SellStock);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "please check sell stock must be less than" + closingStock;
                        return View();
                    }

                    if (_db.ProductMsts.Where(u => u.ProductName == productUpdate.ProductName && u.ProductId != productUpdate.ProductId).Any())
                    {
                        TempData["ErrorMessage"] = "ProductName is already exists.";
                        return View();
                    }
                    else
                    {
                        _db.Entry(productUpdate).State = EntityState.Modified;
                        _db.SaveChanges();
                        return RedirectToAction("ProductList");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var productDelete = _db.ProductMsts.FirstOrDefault(x => x.ProductId == id);
                if (productDelete != null)
                {
                    _db.ProductMsts.Remove(productDelete);
                    _db.SaveChanges();
                    return RedirectToAction("ProductList");
                }
                return RedirectToAction("ProductList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ProductList");
            }
        }

        //[HttpGet]
        //public IActionResult DeleteProduct(int id)
        //{
        //    try
        //    {
        //        var productDetail = _db.ProductMsts.FirstOrDefault(x => x.ProductId == id);
        //        if (productDetail != null)
        //        {
        //            return View(productDetail);
        //        }
        //        return RedirectToAction("ProductList");
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //}

        //[HttpPost]
        //public IActionResult DeleteProduct(ProductMst product)
        //{
        //    try
        //    {
        //        var productDelete = _db.ProductMsts.FirstOrDefault(x => x.ProductId == product.ProductId);
        //        if (productDelete != null)
        //        {
        //            _db.ProductMsts.Remove(productDelete);
        //            _db.SaveChanges();
        //            return RedirectToAction("ProductList");
        //        }
        //        return View();
        //    }

        //    catch (Exception)
        //    {
        //        return View("Error");
        //    } 

        //}

    }
}
