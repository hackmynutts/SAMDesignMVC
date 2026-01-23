using SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.List;
using SAMDesign.Abstractions.DataAccess.EVENTLOG.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.EVENTLOG.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.EVENTLOG.List
{
    public class EventLogList_BL : IEventLogList_BL
    {
        private IEventLogList_DA EventLogList_;
        public EventLogList_BL() 
        {
            EventLogList_ = new EventLogList_DA();
        }

        public List<EventLogDTO> List()
        {
            List<EventLogDTO> eventLogs = EventLogList_.List();
            return eventLogs;
        }
    }
}
