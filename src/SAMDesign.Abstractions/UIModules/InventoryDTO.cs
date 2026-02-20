using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.UIModules
{
    public class InventoryDTO
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Display(Name ="Inventario")]
        public string name { get; set; }
        [Display(Name ="Estado")]
        public int statusID { get; set; }
        [Display(Name ="Creado por")]
        public string createdBy { get; set; }
        [Display(Name ="Creado el")]
        public DateTime createdOn{ get; set; }
        [Display(Name ="Modificado por")]
        public string modifiedBy { get; set; }
        [Display(Name ="Modificado el")]
        public DateTime? modifiedOn{ get; set; }
    }
}
