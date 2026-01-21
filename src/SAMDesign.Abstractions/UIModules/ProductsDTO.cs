using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.UIModules
{
    public class ProductsDTO
    {
        [Display(Name = "#")]
        public int ProductID { get; set; }
        [Display(Name = "Producto")]
        public string ProductName { get; set; }

        [Display(Name = "Categoria")]
        public int CategoryID { get; set; }
        [Display(Name = "Descripcion")]
        public string comments { get; set; }
        [Display(Name = "Precio")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Imagen")]
        public string img_path { get; set; }
        [Display(Name = "Estado")]
        public int statusID { get; set; }
        [Display(Name = "Creado por")]
        public string created_by { get; set; }
        [Display(Name = "Creado el")]
        public DateTime created_on { get; set; }
        [Display(Name = "Modificado por")]
        public string modified_by { get; set; }
        [Display(Name = "Modificado el")]
        public DateTime? modified_on { get; set; }


    }
}
