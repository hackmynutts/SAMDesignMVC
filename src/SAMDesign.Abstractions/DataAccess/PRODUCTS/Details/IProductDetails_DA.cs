using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.PRODUCTS.Details
{
    public interface IProductDetails_DA
    {
        ProductsDTO Get(int id);
    }
}
