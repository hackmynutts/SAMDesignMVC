using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.PRODUCTS.Add
{
    public interface IProductAdd_DA
    {
        Task<int> Add(ProductsDTO product);
    }
}
