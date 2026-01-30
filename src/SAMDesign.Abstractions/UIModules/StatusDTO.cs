using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.UIModules
{
    public class StatusDTO
    {
        [Display(Name ="Status ID")]
        public int statusID { get; set; }
        [Display(Name ="Nombre")]
        public string name{ get; set; }
        [Display(Name = "Creado por")]
        public string createdBy{ get; set; }
        [Display(Name = "Creado el")]
        public DateTime createdOn{ get; set; }
        [Display(Name ="Modificado por")]
        public string modifiedOn{ get; set; }
        [Display(Name ="Modificado en")]
        public DateTime? modifiedBy { get; set; }
    }
}
