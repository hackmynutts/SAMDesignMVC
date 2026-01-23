using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.Entities
{
    [Table("[CATEGORY_TYPE_TB]")]
    public class CategoryDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Category_ID")]
        public int categoryID { get; set; }
        [Column("Description")]
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        public string categoryName { get; set; }
        [Column("Comments")]
        [Required(ErrorMessage = "La descripción de la categoría es obligatoria")]
        public string categoryDescription { get; set; }
        [Column("Status_ID")]
        public int status { get; set; }
        [Column("Created_By")]
        public string createdBy { get; set; }
        [Column("Created_On")]
        public DateTime createdOn { get; set; }
        [Column("Modified_By")]
        public string updatedBy { get; set; }
        [Column("Modified_On")]
        public DateTime? updatedOn { get; set; }
    }
}
