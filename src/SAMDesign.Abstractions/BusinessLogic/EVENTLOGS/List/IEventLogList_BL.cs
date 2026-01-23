using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.List
{
    public interface IEventLogList_BL
    {
        List<EventLogDTO> List();
    }
}
