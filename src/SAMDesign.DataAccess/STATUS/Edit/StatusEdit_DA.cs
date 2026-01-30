using SAMDesign.Abstractions.DataAccess.STATUS.Edit;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.STATUS.Edit
{
    public class StatusEdit_DA : IStatusEdit_DA
    {
        private Context _context;
        public StatusEdit_DA() 
        {
            _context = new Context();
        }

        public async Task<int> Edit (StatusDTO dto)
        {
            int cantEdit=0;
            StatusDA status = _context.Statuses.FirstOrDefault(s => s.statusID == dto.statusID);
            if (status != null)
            {
                status.name = dto.name;
                status.modifiedBy = dto.modifiedBy;
                status.modifiedOn = dto.modifiedOn;
                cantEdit = await _context.SaveChangesAsync();
            }
            return cantEdit;
        }
    }
}
