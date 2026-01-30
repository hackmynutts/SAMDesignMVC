using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.STATUS.Edit
{
    public interface IStatusEdit_DA
    {
        Task<int> Edit (StatusDTO dto);
    }
}
