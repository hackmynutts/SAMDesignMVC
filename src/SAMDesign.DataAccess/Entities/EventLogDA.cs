using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.Entities
{
    [Table("EVENT_LOG_TB")]
    public class EventLogDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Log_ID")]
        public int LogID { get; set; }
        [Column("Table_Name")]
        public string EventTable { get; set; }

        [Column("Type_Event")]
        public string TypeEvent { get; set; }
        [Column("Event_Desc")]
        public string descripcionDeEvento { get; set; }
        [Column("Stack_Trace")]
        public string stackTrace { get; set; }
        [Column("Done_On")]
        public DateTime fechaDeEvento { get; set; }
        [Column("Done_By")]
        public string activadoPor { get; set; }
        [Column("Pre_Data")]
        public string datosAnteriores { get; set; }
        [Column("Post_Data")]
        public string datosPosteriores { get; set; }
    }
}
