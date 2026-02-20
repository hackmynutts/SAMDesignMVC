using SAMDesign.Abstractions.DataAccess.INVENTORY.List;
using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.INVENTORY.List
{
    public class InventoryList_DA : IInventoryList_DA
    {
        private Context _context;
        public InventoryList_DA() 
        {
            _context = new Context();
        }
        public List<InventoryDTO> GetList()
        {
            List<InventoryDTO> inventarios = (from i in _context.Inventories
                                              select new InventoryDTO
                                              {
                                                  id = i.id,
                                                  name = i.name,
                                                  statusID = i.statusID,
                                                  createdBy = i.createdBy,
                                                  createdOn = i.createdOn,
                                                  modifiedBy = i.modifiedBy,
                                                  modifiedOn = i.modifiedOn
                                              }).ToList();
            return inventarios;
        }
    }
}
