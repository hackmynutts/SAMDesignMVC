using SAMDesign.Abstractions.BusinessLogic.STATUS.List;
using SAMDesign.Abstractions.DataAccess.STATUS.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.STATUS.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.STATUS.List
{
    public class StatusList_BL : IStatusList_BL
    {
        private readonly IStatusList_DA _statusList_DA;
        public StatusList_BL()
        {
            _statusList_DA = new StatusList_DA();
        }

        public List<StatusDTO> List()
        {
            List<StatusDTO> statuses = _statusList_DA.List();
            return statuses;
        }
    }
}
