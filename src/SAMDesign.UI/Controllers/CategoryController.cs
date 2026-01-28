using SAMDesign.Abstractions.BusinessLogic.CATEGORY.Add;
using SAMDesign.Abstractions.BusinessLogic.CATEGORY.List;
using SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.Add;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.CATEGORY.Add;
using SAMDesign.BusinessLogic.CATEGORY.List;
using SAMDesign.BusinessLogic.EVENTLOG.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IEventLogAdd_BL _eventLogAddBL;
        private readonly ICategoryAdd_BL _categoryAddBL;
        private readonly ICategoryList_BL _categoryListBL;
        public CategoryController() 
        {
            _eventLogAddBL = new EventLogAdd_BL();
            _categoryAddBL = new CategoryAdd_BL();
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
        public async Task<ActionResult> Create(CategoryDTO category)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = false, message = "Validación inválida." });

                    return PartialView("Create", category);
                }
                category.createdBy = User.Identity.Name;
                int result = await _categoryAddBL.Add(category);

                if (result > 0)
                {
                    EventLogDTO log = new EventLogDTO
                    {
                        EventTable = "Category",
                        TypeEvent = "Create",
                        descripcionDeEvento = $"Categoria creada: {category.categoryName}",
                        fechaDeEvento = DateTime.Now,
                        stackTrace = "Categories/Create/success",
                        activadoPor = User.Identity.Name,
                        datosPosteriores = JsonSerializer.Serialize(category)
                    };
                    int logResult = await _eventLogAddBL.Add(log);
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true, rows = result });

                    return RedirectToAction("List");
                }

                if (Request.IsAjaxRequest())
                    return Json(new { success = false, message = "Error al crear la categoria." });

                ModelState.AddModelError(string.Empty, "Error al crear la categoria.");
                return PartialView("Create", category);

            }
            catch (Exception e)
            {
                var msg = e.GetBaseException().Message;
                ModelState.AddModelError("", "Error al crear la categoria. " + msg);

                EventLogDTO log = new EventLogDTO
                {
                    EventTable = "Category",
                    TypeEvent = "Create/Error",
                    descripcionDeEvento = $"Categoria NO creado: {category.categoryName}",
                    fechaDeEvento = DateTime.Now,
                    stackTrace = e.StackTrace.ToString(),
                    activadoPor = User.Identity.Name,
                    datosPosteriores = JsonSerializer.Serialize(category) //para ver qué datos se intentaron guardar
                };
                int logResult = await _eventLogAddBL.Add(log);
                if (Request.IsAjaxRequest())
                    return Json(new { success = false, message = msg });

                return PartialView("Create", category);
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
