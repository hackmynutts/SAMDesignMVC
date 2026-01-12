using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.List;
using SAMDesign.Abstractions.DataAccess.PRODUCTS.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.PRODUCTS.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.PRODUCTS.List
{
    public class ProductsList_BL : IProductsList_BL
    {
        private readonly IProductList_DA _productList_DA;
        public ProductsList_BL()
        {
            _productList_DA = new ProductList_DA();
        }

        public List<ProductsDTO> Get()
        {

            List<ProductsDTO> products = _productList_DA.Get();
            return products;
        }

        public List<ProductsDTO> GetAdmin()
        {

            List<ProductsDTO> products = _productList_DA.Get();
            return products;
        }
    }
}
