using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Details;
using SAMDesign.Abstractions.DataAccess.PRODUCTS.Details;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.PRODUCTS.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.PRODUCTS.Details
{
    public class ProductDetails_BL : IProductDetails_BL
    {
        private readonly IProductDetails_DA _productDetails_DA;
        public ProductDetails_BL()
        {
            _productDetails_DA = new ProductDetails_DA();
        }

        public ProductsDTO Get(int id)
        {
            ProductsDTO product = _productDetails_DA.Get(id);
            return product;
        }
    }
}
