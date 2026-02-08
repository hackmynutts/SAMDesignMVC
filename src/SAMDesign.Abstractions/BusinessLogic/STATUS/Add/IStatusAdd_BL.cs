using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.STATUS.Add
{
    public interface IStatusAdd_BL
    {
        Task<int> Add(StatusDTO status);
    }
}
