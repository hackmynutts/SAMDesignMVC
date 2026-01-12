using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.PRODUCTS.List
{
    public interface IProductsList_BL
    {
        List<ProductsDTO> Get();
        List<ProductsDTO> GetAdmin();
    }
}
