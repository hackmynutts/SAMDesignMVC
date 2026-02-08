using SAMDesign.Abstractions.DataAccess.STATUS.Add;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.STATUS.Add
{
    public class StatusAdd_DA : IStatusAdd_DA
    {
        private Context _context;
        public StatusAdd_DA()
        {
            _context = new Context();
        }

        public async Task<int> Add(StatusDTO status)
        {
            int cantAdd = 0;
            try
            {
                StatusDA statusDA = Convert2DA(status);
                _context.Statuses.Add(statusDA);
                cantAdd = await _context.SaveChangesAsync();
                return cantAdd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private StatusDA Convert2DA (StatusDTO status)
        {
            StatusDA statusDA = new StatusDA()
            {
                statusID = status.statusID,
                name = status.name,
                createdBy = status.createdBy,
                createdOn = status.createdOn,
                modifiedBy = status.modifiedBy,
                modifiedOn = status.modifiedOn
            };
            return statusDA;
        }
    }
}
