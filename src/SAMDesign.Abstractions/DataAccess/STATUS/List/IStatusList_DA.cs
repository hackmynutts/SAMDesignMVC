using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.STATUS.List
{
    public interface IStatusList_DA
    {
        List<StatusDTO> List();
    }
}
