using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.Entities
{
    [Table("PRODUCT_TB")]
    public class ProductsDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Product_ID")]
        public int ProductID { get; set; }
        [Column("Description")]
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        public string ProductName { get; set; }
        [Column("Category_Type_ID")]
        [Required(ErrorMessage = "La categoría es requerida.")]
        public int CategoryID { get; set; }
        [Column("Comments")]
        [Required(ErrorMessage = "La informacion es requeridos.")]
        public string comments { get; set; }
        [Column("Unit_price")]
        public decimal UnitPrice { get; set; }
        [Column("Image_path")]
        public string img_path { get; set; }
        [Column("Status_ID")]
        public int statusID { get; set; }
        [Column("Created_By")]
        public string created_by { get; set; }
        [Column("Created_On")]
        public DateTime created_on { get; set; }
        [Column("Modified_By")]
        public string modified_by { get; set; }
        [Column("Modified_On")]
        public DateTime? modified_on { get; set; }
        
    }
}
