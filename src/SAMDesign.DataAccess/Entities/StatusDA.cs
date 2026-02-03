using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.Entities
{
    [Table("STATUS_TB")]
    public class StatusDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Status_ID")]
        public int statusID { get; set; }
        [Column("Description")]
        [Required(ErrorMessage ="El nombre es requerido.")]
        public string name { get; set; }
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
