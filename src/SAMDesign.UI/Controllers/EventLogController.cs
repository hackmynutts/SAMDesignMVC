using SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.EVENTLOG.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class EventLogController : Controller
    {
        private readonly IEventLogList_BL _eventLogListBL;
        public EventLogController()
        {
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
