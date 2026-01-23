using SAMDesign.Abstractions.DataAccess.EVENTLOG.List;
using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.EVENTLOG.List
{
    public class EventLogList_DA : IEventLogList_DA
    {
        private readonly Context _context;
        public EventLogList_DA() 
        {
            _context = new Context();
        }

        public List<EventLogDTO> List()
        {
            List<EventLogDTO> lista = (from evento in _context.EventLogs
                                       select new EventLogDTO
                                       {
                                             LogID = evento.LogID,
                                             EventTable = evento.EventTable,
                                             TypeEvent = evento.TypeEvent,
                                             descripcionDeEvento = evento.descripcionDeEvento,
                                             stackTrace = evento.stackTrace,
                                             fechaDeEvento = evento.fechaDeEvento,
                                             activadoPor = evento.activadoPor,
                                             datosAnteriores = evento.datosAnteriores,
                                             datosPosteriores = evento.datosPosteriores
                                       }).ToList();
            return lista;
        }
    }
}
