using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Add
{
    public interface IProductAdd_BL
    {
        Task<int> Add(ProductsDTO product);
    }
}
