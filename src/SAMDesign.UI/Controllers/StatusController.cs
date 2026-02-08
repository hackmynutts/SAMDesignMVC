using SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.Add;
using SAMDesign.Abstractions.BusinessLogic.STATUS.Add;
using SAMDesign.Abstractions.BusinessLogic.STATUS.Details;
using SAMDesign.Abstractions.BusinessLogic.STATUS.Edit;
using SAMDesign.Abstractions.BusinessLogic.STATUS.List;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.EVENTLOG.Add;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.BusinessLogic.STATUS.Add;
using SAMDesign.BusinessLogic.STATUS.Details;
using SAMDesign.BusinessLogic.STATUS.Edit;
using SAMDesign.BusinessLogic.STATUS.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class StatusController : Controller
    {
        private readonly IEventLogAdd_BL _eventLogAddBL;
        private readonly Idate _date;
        private readonly IStatusAdd_BL _statusAddBL;
        private readonly IStatusEdit_BL _statusEditBL;
        private readonly IStatusDetails_BL _statusDetailsBL;
        private readonly IStatusList_BL _statusListBL;
        public StatusController() 
        {
            _eventLogAddBL = new EventLogAdd_BL();
            _date = new date();
            _statusAddBL = new StatusAdd_BL();
            _statusEditBL = new StatusEdit_BL();
            _statusDetailsBL = new StatusDetails_BL();
            _statusListBL = new StatusList_BL();
        }

        // GET: Status
        public ActionResult List()
        {
            List<StatusDTO> statusList = _statusListBL.List();
            return PartialView(statusList);
        }

        // GET: Status/Details/5
        public ActionResult Details(int id)
        {
            return PartialView();
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Status/Create
        [HttpPost]
        public async Task<ActionResult> Create(StatusDTO status)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = false, message = "Validación inválida."});
                    return PartialView("Create", status);
                }
                status.createdBy = User.Identity.Name;
                int cantCreated = await _statusAddBL.Add(status);

                if (cantCreated > 0)
                {
                    EventLogDTO log = new EventLogDTO
                    {
                        EventTable = "Status",
                        TypeEvent = "Create",
                        descripcionDeEvento = $"Status creado: {status.name}",
                        fechaDeEvento = _date.GetDate(),
                        stackTrace = "Status/Create/success",
                        activadoPor = User.Identity.Name,
                        datosPosteriores = JsonSerializer.Serialize(status)
                    };
                    int logResult = await _eventLogAddBL.Add(log);
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true, rows = cantCreated });

                    return RedirectToAction("List");
                }
                else
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = false, message = "No se realizaron cambios." });
                    ModelState.AddModelError(string.Empty, "Error al crear el estado.");
                    return PartialView("Create", status);
                }
            }
            catch (Exception ex)
            {
                EventLogDTO log = new EventLogDTO
                {
                    EventTable = "Status",
                    TypeEvent = "Edit/Fail",
                    descripcionDeEvento = $"Error al crear el estado: {status.name}",
                    fechaDeEvento = _date.GetDate(),
                    stackTrace = ex.StackTrace,
                    activadoPor = User.Identity.Name,
                    datosPosteriores = JsonSerializer.Serialize(status)
                };
                int logResult = await _eventLogAddBL.Add(log);
                if (Request.IsAjaxRequest())
                    return Json(new { success = false, message = "Error al crear el estado." });
                return PartialView("Create", status);
            }
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int id)
        {
            StatusDTO status = _statusDetailsBL.Get(id);
            return PartialView(status);
        }

        // POST: Status/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit( StatusDTO status)
        {
            StatusDTO statusPrev = _statusDetailsBL.Get(status.statusID);
            try
            {
                if(!ModelState.IsValid)
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = false, message = "Validación inválida." });
                    return PartialView("Edit",status);
                }

                status.modifiedBy = User.Identity.Name;
                int cantEdit = await _statusEditBL.Edit(status);

                if (cantEdit > 0)
                {
                    EventLogDTO log = new EventLogDTO
                    {
                        EventTable = "Status",
                        TypeEvent = "Edit",
                        descripcionDeEvento = $"Status editado: {status.name}",
                        fechaDeEvento = _date.GetDate(),
                        stackTrace = "Status/Edit/success",
                        activadoPor = User.Identity.Name,
                        datosAnteriores = JsonSerializer.Serialize(statusPrev),
                        datosPosteriores = JsonSerializer.Serialize(status)
                    };
                    int logResult = await _eventLogAddBL.Add(log);
                    if (Request.IsAjaxRequest())
                        return Json(new { success = true, rows = cantEdit });

                    return RedirectToAction("List");
                }
                else
                {
                    if (Request.IsAjaxRequest())
                        return Json(new { success = false, message = "No se realizaron cambios." });
                    ModelState.AddModelError(string.Empty, "Error al crear el estado.");
                    return PartialView("Edit", status);
                }
            }
            catch (Exception ex)
            {
                EventLogDTO log = new EventLogDTO
                {
                    EventTable = "Status",
                    TypeEvent = "Edit/Fail",
                    descripcionDeEvento = $"Error al editar el Status: {status.name}",
                    fechaDeEvento = _date.GetDate(),
                    stackTrace = ex.StackTrace,
                    activadoPor = User.Identity.Name,
                    datosAnteriores = JsonSerializer.Serialize(statusPrev),
                    datosPosteriores = JsonSerializer.Serialize(status)
                    };
                int logResult = await _eventLogAddBL.Add(log);
                if (Request.IsAjaxRequest())
                    return Json(new { success = false, message = "Error al editar el Status." });
                return PartialView("Edit", status);
            }
        }

        // POST: Status/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("List");
            }
            catch
            {
                return PartialView();
            }
        }
    }
}
