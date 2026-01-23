using SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.Add;
using SAMDesign.Abstractions.DataAccess.EVENTLOG.Add;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.DataAccess.EVENTLOG.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.EVENTLOG.Add
{
    public class EventLogAdd_BL : IEventLogAdd_BL
    {
        private Idate _date;
        private readonly IEventLogAdd_DA _eventLogAddDA;
        public EventLogAdd_BL() 
        {
            _date = new date();
            _eventLogAddDA = new EventLogAdd_DA();
        }

        public async Task<int> Add(EventLogDTO log)
        {
            log.fechaDeEvento = _date.GetDate();
            int result = await _eventLogAddDA.Add(log);
            return result;
        }

    }
}
