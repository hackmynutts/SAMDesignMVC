using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.STATUS.Edit
{
    public interface IStatusEdit_BL
    {
        Task<int> Edit (StatusDTO dto);
    }
}
