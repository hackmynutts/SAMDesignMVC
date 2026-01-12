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
        public string ProductName { get; set; }
        [Column("Category_Type_ID")]
        public int CategoryID { get; set; }
        [Column("Comments")]
        public string comments { get; set; }
        [Column("Unit_price")]
        public decimal UnitPrice { get; set; }
        [Column("Image_path")]
        public short img_path { get; set; }
        [Column("Status_ID")]
        public short statusID { get; set; }
        [Column("Created_By")]
        public short created_by { get; set; }
        [Column("Created_On")]
        public short created_on { get; set; }
        [Column("Modified_On")]
        public short modified_on { get; set; }
        [Column("Modified_By")]
        public short modified_by { get; set; }
    }
}
