using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.PRODUCTS.Details;
using SAMDesign.BusinessLogic.PRODUCTS.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsList_BL _productsList_BL;
        private ProductDetails_BL _productsDetails_BL;
        public ProductsController()
        {
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("List");
            }
            catch
            {
                return View();
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
