using SAMDesign.Abstractions.BusinessLogic.STATUS.Delete;
using SAMDesign.Abstractions.DataAccess.STATUS.Delete;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.DataAccess.STATUS.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.STATUS.Delete
{
    public class StatusDelete_BL : IStatusDelete_BL
    {
        private readonly IStatusDelete_DA _statusDeleteDA;
        public StatusDelete_BL()
        {
            _statusDeleteDA = new StatusDelete_DA();
        }

        public async Task<bool> Delete(int id)
        {
            bool result = await _statusDeleteDA.Delete(id);
            return result;
        }
    }
}
