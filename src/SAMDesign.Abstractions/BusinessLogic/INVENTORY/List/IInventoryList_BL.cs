using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.INVENTORY.List
{
    public interface IInventoryList_BL
    {
        List<InventoryDTO> GetList();
    }
}
