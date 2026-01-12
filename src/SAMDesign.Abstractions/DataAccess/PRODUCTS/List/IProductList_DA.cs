using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.PRODUCTS.List
{
    public interface IProductList_DA
    {
        List<ProductsDTO> Get();
        List<ProductsDTO> GetAdmin();
    }
}
