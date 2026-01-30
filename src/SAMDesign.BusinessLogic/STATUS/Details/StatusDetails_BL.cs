using SAMDesign.Abstractions.BusinessLogic.STATUS.Details;
using SAMDesign.Abstractions.DataAccess.STATUS.Details;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.STATUS.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.STATUS.Details
{
    public class StatusDetails_BL : IStatusDetails_BL
    {
        private readonly IStatusDetails_DA _statusDetailsDA;
        public StatusDetails_BL()
        {
            _statusDetailsDA = new StatusDetails_DA();
        }
        public StatusDTO Get(int id)
        {
            return _statusDetailsDA.Get(id);
        }
    }
}
