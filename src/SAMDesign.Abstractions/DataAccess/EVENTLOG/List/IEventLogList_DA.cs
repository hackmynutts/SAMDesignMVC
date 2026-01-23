using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.EVENTLOG.List
{
    public interface IEventLogList_DA
    {
        List<EventLogDTO> List();
    }
}
