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
        public short img_path { get; set; }
        [Display(Name = "Estado")]
        public short statusID { get; set; }
        [Display(Name = "Creado por")]
        public short created_by { get; set; }
        [Display(Name = "Creado el")]
        public short created_on { get; set; }
        [Display(Name = "Modificado por")]
        public short modified_on { get; set; }
        [Display(Name = "Modificado en")]
        public short modified_by { get; set; }

    }
}
