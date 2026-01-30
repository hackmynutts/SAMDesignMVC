using SAMDesign.Abstractions.DataAccess.STATUS.Details;
using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.STATUS.Details
{
    public class StatusDetails_DA : IStatusDetails_DA
    {
        private Context _context;
        public StatusDetails_DA() 
        {
            _context = new Context();
        }
        public StatusDTO Get(int id)
        {
            StatusDTO status = (from s in _context.Statuses
                                where s.statusID == id
                                select new StatusDTO
                                {
                                    statusID = s.statusID,
                                    name = s.name,
                                    createdBy = s.createdBy,
                                    createdOn = s.createdOn,
                                    modifiedOn = s.modifiedOn,
                                    modifiedBy = s.modifiedBy   
                                }).FirstOrDefault();
            return status;
        }
    }
}
