using SAMDesign.Abstractions.DataAccess.EVENTLOG.Add;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.EVENTLOG.Add
{
    public class EventLogAdd_DA : IEventLogAdd_DA
    {
        private Context _Context;
        public EventLogAdd_DA() 
        {
            _Context = new Context();
        }

        public async Task<int> Add(EventLogDTO log)
        {
            int LogLines = 0;
            EventLogDA eventLog = convert2DA(log);
            _Context.EventLogs.Add(eventLog);
            LogLines = await _Context.SaveChangesAsync();
            return LogLines;
        }

        public EventLogDA convert2DA (EventLogDTO dto)
        {
            EventLogDA el = new EventLogDA
            {
                LogID = dto.LogID,
                EventTable = dto.EventTable,
                TypeEvent = dto.TypeEvent,
                descripcionDeEvento = dto.descripcionDeEvento,
                stackTrace = dto.stackTrace,
                fechaDeEvento = dto.fechaDeEvento,
                activadoPor = dto.activadoPor,
                datosAnteriores = dto.datosAnteriores,
                datosPosteriores = dto.datosPosteriores
            };
            return el;
        }
    }
}
