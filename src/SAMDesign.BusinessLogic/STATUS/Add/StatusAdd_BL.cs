using SAMDesign.Abstractions.BusinessLogic.STATUS.Add;
using SAMDesign.Abstractions.DataAccess.STATUS.Add;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.DataAccess.STATUS.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.STATUS.Add
{
    public class StatusAdd_BL : IStatusAdd_BL
    {
        private Idate _date;
        private readonly IStatusAdd_DA _statusAddDA;
        public StatusAdd_BL()
        {
            _date = new date();
            _statusAddDA = new StatusAdd_DA();
        }

        public async Task<int> Add(StatusDTO status)
        {
            status.createdOn = _date.GetDate();
            int cantAdd =  await _statusAddDA.Add(status);
            return cantAdd;
        }

    }
}
