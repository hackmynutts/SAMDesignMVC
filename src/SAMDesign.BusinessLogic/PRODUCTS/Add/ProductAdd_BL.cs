using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Add;
using SAMDesign.Abstractions.DataAccess.PRODUCTS.Add;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.general.DateManagement;
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
        private readonly Idate _date;
        public ProductAdd_BL()
        {
            _productAdd_DA = new ProductAdd_DA();
            _date = new date();
        }

        public async Task<int> Add(ProductsDTO product)
        {
            product.created_on = _date.GetDate();
            product.statusID = 13; // Active status
            int result = await _productAdd_DA.Add(product);
            return result;
        }
    }
}
