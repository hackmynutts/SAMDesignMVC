using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.Entities
{
    [Table("INVENTORY_TB")]
    public class InventoryDA
    {
        [Column("Inventory_ID")]
        public int id { get; set; }
        [Column("Description")]
        [Required(ErrorMessage = "El nombre del inventario es obligatorio")]
        public string name { get; set; }
        [Column("Status_ID")]
        public int statusID { get; set; }
        [Column("Created_By")]
        public string createdBy { get; set; }
        [Column("Created_On")]
        public DateTime createdOn { get; set; }
        [Column("Modified_By")]
        public string modifiedBy { get; set; }
        [Column("Modified_On")]
        public DateTime? modifiedOn { get; set; }
    }
}