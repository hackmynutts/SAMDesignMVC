using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.UIModules
{
    public class CategoryDTO
    {
        [Display(Name = "#")]
        public int categoryID{ get; set; }
        [Display(Name = "Categoría")]
        public string categoryName { get; set; }
        [Display(Name = "Descripción")]
        public string categoryDescription { get; set; }
        [Display(Name = "Estado")]
        public int status { get; set; }
        [Display(Name = "Creado por")]
        public string createdBy { get; set; }
        [Display(Name = "Creado el")]
        public DateTime createdOn { get; set; }
        [Display(Name = "Actualizado por")]
        public string updatedBy { get; set; }
        [Display(Name = "Actualizado el")]
        public DateTime? updatedOn { get; set; }
    }
}
