using SAMDesign.Abstractions.BusinessLogic.PRODUCTS.Edit;
using SAMDesign.Abstractions.DataAccess.PRODUCTS.Edit;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.DataAccess.PRODUCTS.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.PRODUCTS.Edit
{
    public class ProductEdit_BL : IProductEdit_BL
    {
        private readonly Idate IDate;
        private readonly IProductEdit_DA _productEdit_DA;
        public ProductEdit_BL()
        {
            IDate = new date();
            _productEdit_DA = new ProductEdit_DA();
        }

        public async Task<int> Edit( ProductsDTO product)
        {
            product.modified_on = IDate.GetDate();
            int result = await _productEdit_DA.Edit(product);
            return result;
        }

    }
}
