using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.STATUS.Delete
{
    public interface IStatusDelete_BL
    {
        Task<bool> Delete(int id);
    }
}
