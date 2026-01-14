using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Add;
using SAMDesign.Abstractions.DataAccess.PRODUCTS.Add;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.PRODUCTS.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.PRODUCTS.Add
{
    public class ProductAdd_BL : IProductAdd_BL
    {
        private readonly IProductAdd_DA _productAdd_DA;
        public ProductAdd_BL()
        {
            _productAdd_DA = new ProductAdd_DA();
        }

        public async Task<int> Add(ProductsDTO product)
        {
            int result = await _productAdd_DA.Add(product);
            return result;
        }
    }
}
