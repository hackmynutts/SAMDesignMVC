using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.STATUS.Details
{
    public interface IStatusDetails_BL
    {
        StatusDTO Get(int id);
    }
}
