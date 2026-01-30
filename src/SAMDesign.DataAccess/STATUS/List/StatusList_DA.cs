using SAMDesign.Abstractions.DataAccess.STATUS.List;
using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.STATUS.List
{
    public class StatusList_DA : IStatusList_DA
    {

        private Context _context;
        public StatusList_DA() 
        {
            _context = new Context();
        }

        public List<StatusDTO> List()
        {
            List<StatusDTO> statusList = (from s in _context.Statuses
                                          select new StatusDTO
                                          {
                                                statusID = s.statusID,
                                                name = s.name,
                                                createdBy = s.createdBy,
                                                createdOn = s.createdOn,
                                                modifiedBy = s.modifiedBy,
                                                modifiedOn = s.modifiedOn
                                          }).ToList();
            return statusList;
        }
    }
}
