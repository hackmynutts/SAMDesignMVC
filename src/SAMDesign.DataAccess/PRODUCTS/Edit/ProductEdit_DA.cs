using SAMDesign.Abstractions.DataAccess.PRODUCTS.Edit;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.PRODUCTS.Edit
{
    public class ProductEdit_DA : IProductEdit_DA
    {
        private Context _context;
        public ProductEdit_DA() 
        {
            _context = new Context();
        }

        public async Task<int> Edit( ProductsDTO product)
        {
            int rowsAffected = 0;
            ProductsDA productsDA = _context.Products.
                                    Where(p => p.ProductID == product.ProductID).
                                    FirstOrDefault();
            if (productsDA != null)
            {
                productsDA.ProductName = product.ProductName;
                productsDA.CategoryID = product.CategoryID;
                productsDA.comments = product.comments;
                productsDA.UnitPrice = product.UnitPrice;
                productsDA.img_path = product.img_path;
                productsDA.statusID = product.statusID;
                productsDA.modified_by = product.modified_by;
                productsDA.modified_on = product.modified_on;
                rowsAffected = await _context.SaveChangesAsync();
            }
            return rowsAffected;
        }
    }
}
