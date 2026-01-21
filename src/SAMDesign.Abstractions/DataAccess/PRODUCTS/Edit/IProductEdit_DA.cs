using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.PRODUCTS.Edit
{
    public interface IProductEdit_DA
    {
        Task<int> Edit( ProductsDTO product);
    }
}
