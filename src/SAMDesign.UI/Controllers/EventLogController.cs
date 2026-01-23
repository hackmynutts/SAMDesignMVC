using SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.Add;
using SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.EVENTLOG.Add;
using SAMDesign.BusinessLogic.EVENTLOG.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class EventLogController : Controller
    {
        private readonly IEventLogAdd_BL _eventLogAddBL;
        private readonly IEventLogList_BL _eventLogListBL;
        public EventLogController()
        {
            _eventLogAddBL = new EventLogAdd_BL();
            _eventLogListBL = new EventLogList_BL();
        }
        // GET: EventLog
        public ActionResult ListLogs()
        {
            List<EventLogDTO> eventLogs = _eventLogListBL.List();
            return View(eventLogs);
        }

        // GET: EventLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventLog/Create
        [HttpPost]
        public async Task<ActionResult> Create(EventLogDTO eventLog)
        {
            try
            {
                eventLog.activadoPor = User.Identity.Name; //capturar quien hizo la accion.
                int cantAdded = await _eventLogAddBL.Add(eventLog);

                if(cantAdded > 0)
                {
                    TempData["SuccessMessage"] = "Event log created successfully.";
                    return RedirectToAction("Index");
                }
                TempData["Mensaje"] = "⚠️ No se pudo registrar el evento.";
                return View(eventLog);
            }
            catch (Exception ex)
            {

                TempData["Mensaje"] = "❌ Error al registrar evento: " + ex.Message;

                eventLog.EventTable = "EventLog";
                eventLog.TypeEvent = "Error";
                eventLog.datosPosteriores= eventLog.ToString();
                await _eventLogAddBL.Add(eventLog);

                TempData["Mensaje"] = "Error al registrar evento: " + ex.Message;

                return View(eventLog);
            }

        }
    }
}
