using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Add;
using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Details;
using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.PRODUCTS.Add;
using SAMDesign.BusinessLogic.PRODUCTS.Details;
using SAMDesign.BusinessLogic.PRODUCTS.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductAdd_BL _productAdd_BL;
        private IProductsList_BL _productsList_BL;
        private IProductDetails_BL _productsDetails_BL;
        public ProductsController()
        {
            _productAdd_BL = new ProductAdd_BL();
            _productsList_BL = new ProductsList_BL();
            _productsDetails_BL = new ProductDetails_BL();
        }
        // GET: Products
        public ActionResult List()
        {
            List<ProductsDTO> products = _productsList_BL.Get();
            return View(products);
        }

        // GET: Products
        public ActionResult ListAdmin()
        {
            List<ProductsDTO> products = _productsList_BL.GetAdmin();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            ProductsDTO product = _productsDetails_BL.Get(id);
            return View(product);
        }

        // GET: Products/Create
        public async Task<ActionResult> Create()
        {
            return PartialView();
        }

        // POST: Products/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProductsDTO product)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    if (Request.IsAjaxRequest())
                        return PartialView(product);
                    return PartialView(product);
                }
                int result = await _productAdd_BL.Add(product);

                if (result > 0)
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true });
                    return RedirectToAction("ListAdmin");
                }

                ModelState.AddModelError(string.Empty, "Error al crear la palabra clave.");
                if (Request.IsAjaxRequest())
                {
                    return PartialView(product);
                }
                return PartialView(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear la palabra clave. " + ex.GetBaseException().Message);


                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, error = ex.GetBaseException().Message });
                }
                return PartialView(product);

            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
