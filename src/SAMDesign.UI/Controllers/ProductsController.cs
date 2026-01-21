using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Add;
using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Details;
using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Edit;
using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.PRODUCTS.Add;
using SAMDesign.BusinessLogic.PRODUCTS.Details;
using SAMDesign.BusinessLogic.PRODUCTS.Edit;
using SAMDesign.BusinessLogic.PRODUCTS.List;
using System;
using System.Collections.Generic;
using System.IO;
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
        private IProductEdit_BL _productEdit_BL;
        public ProductsController()
        {
            _productAdd_BL = new ProductAdd_BL();
            _productEdit_BL = new ProductEdit_BL();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductsDTO model, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (!ModelState.IsValid)
                    return PartialView("Create", model);

                // Guardar imagen si viene
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ImageFile.FileName); //retorna solo el nombre del archivo
                    string folder = Server.MapPath("~/Content/Images/Products/"); //carpeta donde se va a guardar la imagen
                    Directory.CreateDirectory(folder); // Crear el directorio si no existe

                    string fullPath = Path.Combine(folder, fileName); //ruta completa
                    ImageFile.SaveAs(fullPath); //guardar la imagen en el servidor

                    model.img_path = "/Content/Images/Products/" + fileName; //guardar la ruta relativa en el modelo
                }
                model.created_by = User.Identity.Name;
                int result = await _productAdd_BL.Add(model);

                if (result > 0)
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true });

                    return RedirectToAction("ListAdmin");
                }

                ModelState.AddModelError(string.Empty, "Error al crear el producto.");
                return PartialView("Create", model);
            }
            catch (Exception ex)
            {
                var msg = ex.GetBaseException().Message;
                ModelState.AddModelError("", "Error al crear el producto. " + msg);

                if (Request.IsAjaxRequest())
                    return Json(new { success = false, error = msg });

                return PartialView("Create", model);
            }
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ProductsDTO product = _productsDetails_BL.Get(id);
            return PartialView(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductsDTO model, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (!ModelState.IsValid)
                    return PartialView(model);

                // Guardar imagen si viene
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ImageFile.FileName); //retorna solo el nombre del archivo
                    string folder = Server.MapPath("~/Content/Images/Products/"); //carpeta donde se va a guardar la imagen
                    Directory.CreateDirectory(folder); // Crear el directorio si no existe

                    string fullPath = Path.Combine(folder, fileName); //ruta completa
                    ImageFile.SaveAs(fullPath); //guardar la imagen en el servidor

                    model.img_path = "/Content/Images/Products/" + fileName; //guardar la ruta relativa en el modelo
                }
                model.modified_by = User.Identity.Name;
                int result = await _productEdit_BL.Edit(model);

                if (result > 0)
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true });
                    return RedirectToAction("ListAdmin");
                }

                ModelState.AddModelError(string.Empty, "Error al crear el producto.");
                return RedirectToAction("Edit", model);

            }
            catch (Exception ex)
            {
                var msg = ex.GetBaseException().Message;
                ModelState.AddModelError("", "Error al editar el producto. " + msg);
                if (Request.IsAjaxRequest())
                    return Json(new { success = false, error = msg });
                return RedirectToAction("Edit", model);
            }
        }
    }
}
