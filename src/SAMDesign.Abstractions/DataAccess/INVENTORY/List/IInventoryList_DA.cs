using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.INVENTORY.List
{
    public interface IInventoryList_DA
    {
        List<InventoryDTO> GetList();
    }
}
