using SAMDesign.Abstractions.BusinessLogic.CATEGORY.Add;
using SAMDesign.Abstractions.BusinessLogic.CATEGORY.Details;
using SAMDesign.Abstractions.BusinessLogic.CATEGORY.Edit;
using SAMDesign.Abstractions.BusinessLogic.CATEGORY.List;
using SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.Add;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.CATEGORY.Add;
using SAMDesign.BusinessLogic.CATEGORY.Details;
using SAMDesign.BusinessLogic.CATEGORY.Edit;
using SAMDesign.BusinessLogic.CATEGORY.List;
using SAMDesign.BusinessLogic.EVENTLOG.Add;
using SAMDesign.BusinessLogic.general.DateManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace SAMDesign.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Idate idate;
        private readonly IEventLogAdd_BL _eventLogAddBL;
        private readonly ICategoryAdd_BL _categoryAddBL;
        private readonly ICategoryDetails_BL _categoryDetailsBL;
        private readonly ICategoryEdit_BL _categoryEditBL;
        private readonly ICategoryList_BL _categoryListBL;
        public CategoryController()
        {
            idate = new date();
            _eventLogAddBL = new EventLogAdd_BL();
            _categoryAddBL = new CategoryAdd_BL();
            _categoryDetailsBL = new CategoryDetails_BL();
            _categoryEditBL = new CategoryEdit_BL();
            _categoryListBL = new CategoryList_BL();
        }
        // GET: Category
        public ActionResult List()
        {
            List<CategoryDTO> categories = _categoryListBL.ListActive();
            return PartialView(categories);
        }

        // GET: Category
        public ActionResult ListAdmin()
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
                if (!ModelState.IsValid)
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
                        fechaDeEvento = idate.GetDate(),
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
                    fechaDeEvento = idate.GetDate(),
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
            CategoryDTO category = _categoryDetailsBL.Get(id);
            return PartialView(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(CategoryDTO category)
        {
            try
            {
                CategoryDTO categoryPrev = _categoryDetailsBL.Get(category.categoryID);
                if (!ModelState.IsValid)
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = false, message = "Validación inválida." });

                    return PartialView("Edit", category);
                }

                category.updatedBy = User.Identity.Name;
                int cantEdited = await _categoryEditBL.Edit(category);

                if (cantEdited > 0)
                {
                    EventLogDTO log = new EventLogDTO
                    {
                        EventTable = "Category",
                        TypeEvent = "Edit",
                        descripcionDeEvento = $"Categoria editada: {category.categoryName}",
                        fechaDeEvento = idate.GetDate(),
                        stackTrace = "Categories/Edit/success",
                        activadoPor = User.Identity.Name,
                        datosAnteriores = JsonSerializer.Serialize(categoryPrev),
                        datosPosteriores = JsonSerializer.Serialize(category)
                    };
                    int logResult = await _eventLogAddBL.Add(log);
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true, rows = cantEdited });
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
                CategoryDTO categoryPrev = _categoryDetailsBL.Get(category.categoryID);
                ModelState.AddModelError("", "Error al editar la categoria. " + msg);
                EventLogDTO log = new EventLogDTO
                {
                    EventTable = "Category",
                    TypeEvent = "Edit/Error",
                    descripcionDeEvento = $"Categoria NO editada: {category.categoryName}",
                    fechaDeEvento = idate.GetDate(),
                    stackTrace = e.StackTrace.ToString(),
                    activadoPor = User.Identity.Name,
                    datosAnteriores = JsonSerializer.Serialize(categoryPrev),
                    datosPosteriores = JsonSerializer.Serialize(category) //para ver qué datos se intentaron guardar
                };
                int logResult = await _eventLogAddBL.Add(log);
                if (Request.IsAjaxRequest())
                    return Json(new { success = false, message = msg });
                return PartialView("Edit", category);
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                CategoryDTO categoryPrev = _categoryDetailsBL.Get(id);
                CategoryDTO category = _categoryDetailsBL.Get(id);
                category.updatedBy = User.Identity.Name;
                category.status = 14; //soft delete
                int result = await _categoryEditBL.Edit(category);
                if (result > 0)
                {
                    EventLogDTO log = new EventLogDTO
                    {
                        EventTable = "Categoria",
                        TypeEvent = "Delete",
                        descripcionDeEvento = $"Categoria eliminado: {category.categoryName}",
                        fechaDeEvento = idate.GetDate(),
                        stackTrace = "Categoria/Delete/success",
                        activadoPor = User.Identity.Name,
                        datosAnteriores = JsonSerializer.Serialize(categoryPrev),
                        datosPosteriores = JsonSerializer.Serialize(category)
                    };
                    int logResult = await _eventLogAddBL.Add(log);
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true, rows = result });

                    //SI NO ES AJAX: redirect normal
                    return RedirectToAction("Lista");
                }

                if (Request.IsAjaxRequest())
                    return Json(new { success = false, message = "No se pudo eliminar/inactivar." });

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                var msg = ex.GetBaseException().Message;
                ModelState.AddModelError("", "Error al eliminar la categoria." + msg);
                EventLogDTO log = new EventLogDTO
                {
                    EventTable = "Category",
                    TypeEvent = "Delete/Error",
                    descripcionDeEvento = $"Categoria NO eliminado: ID {id}",
                    fechaDeEvento = idate.GetDate(),
                    stackTrace = ex.StackTrace
                };
                int logResult = await _eventLogAddBL.Add(log);
                if (Request.IsAjaxRequest())
                    return Json(new { success = false });
                return RedirectToAction("Edit");

            }
        }
    }
}
