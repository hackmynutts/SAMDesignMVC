using SAMDesign.Abstractions.BusinessLogic.CATEGORY.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.CATEGORY.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryList_BL _categoryListBL;
        public CategoryController() 
        {
            _categoryListBL = new CategoryList_BL();
        }
        // GET: Category
        public ActionResult List()
        {
            List<CategoryDTO> categories = _categoryListBL.List();
            return PartialView(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView();
            }
        }
    }
}
