using SAMDesign.Abstractions.BusinessLogic.STATUS.List;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.BusinessLogic.STATUS.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class StatusController : Controller
    {
        private readonly Idate _date;
        private readonly IStatusList_BL _statusListBL;
        public StatusController() 
        {
            _date = new date();
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
            return View();
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
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

        // GET: Status/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Status/Edit/5
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
                return View();
            }
        }
    }
}
