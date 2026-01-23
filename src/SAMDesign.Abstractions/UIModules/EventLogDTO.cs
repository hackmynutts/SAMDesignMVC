using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.UIModules
{
    public class EventLogDTO
    {
            [Display(Name = "ID del Evento")]
            public int LogID { get; set; }

            [Display(Name = "Tabla del Evento")]
            public string EventTable { get; set; }

            [Display(Name = "Tipo de Evento")]
            public string TypeEvent { get; set; }
            [Display(Name = "Descripción del Evento")]
            public string descripcionDeEvento { get; set; }
            [Display(Name = "Stack Trace")]
            public string stackTrace { get; set; }
            [Display(Name = "Fecha del Evento")]
            public DateTime fechaDeEvento { get; set; }
            [Display(Name = "Activado Por")]
            public string activadoPor { get; set; }
            [Display(Name = "Datos Anteriores")]
            public string datosAnteriores { get; set; }
            [Display(Name = "Datos Posteriores")]
            public string datosPosteriores { get; set; }
        }
}
