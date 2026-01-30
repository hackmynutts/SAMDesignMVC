using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.STATUS.Details
{
    public interface IStatusDetails_DA
    {
        StatusDTO Get(int id);
    }
}
