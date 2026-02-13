using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.STATUS.Delete
{
    public interface IStatusDelete_DA
    {
        Task<bool> Delete(int id);
    }
}
