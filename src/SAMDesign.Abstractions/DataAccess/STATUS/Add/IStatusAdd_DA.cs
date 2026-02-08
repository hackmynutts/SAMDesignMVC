using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.STATUS.Add
{
    public interface IStatusAdd_DA
    {
        Task<int> Add(StatusDTO status);
    }
}
