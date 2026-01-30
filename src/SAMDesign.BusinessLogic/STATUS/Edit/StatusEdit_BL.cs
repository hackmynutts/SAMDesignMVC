using SAMDesign.Abstractions.BusinessLogic.STATUS.Edit;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.DataAccess.STATUS.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.STATUS.Edit
{
    public class StatusEdit_BL : IStatusEdit_BL
    {
        private readonly Idate _date;
        private readonly StatusEdit_DA _statusEditDA;
        public StatusEdit_BL()
        {
            _date = new date();
            _statusEditDA = new StatusEdit_DA();
        }
        public async Task<int> Edit (StatusDTO dto)
        {
            dto.modifiedOn = _date.GetDate();
            int result = await _statusEditDA.Edit(dto);
            return result;
        }
    }
}
