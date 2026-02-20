using SAMDesign.Abstractions.BusinessLogic.INVENTORY.List;
using SAMDesign.Abstractions.DataAccess.INVENTORY.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.INVENTORY.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.INVENTORY.List
{
    public class InventoryList_BL : IInventoryList_BL
    {
        private readonly IInventoryList_DA _inventory;
        public InventoryList_BL() 
        {
            _inventory = new InventoryList_DA();
        }
        public List<InventoryDTO> GetList() 
        {
            List<InventoryDTO> inventarios = _inventory.GetList();
            return inventarios;
        }
    }
}
