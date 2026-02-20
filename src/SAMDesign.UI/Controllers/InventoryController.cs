using SAMDesign.Abstractions.BusinessLogic.INVENTORY.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.INVENTORY.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMDesign.UI.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryList_BL _inventoryListBL;
        public InventoryController() 
        {
            _inventoryListBL = new InventoryList_BL();
        }
        // GET: Inventory
        public ActionResult List()
        {
            List<InventoryDTO> inventoryList = _inventoryListBL.GetList();
            return View(inventoryList);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
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

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventory/Edit/5
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

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Delete/5
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
