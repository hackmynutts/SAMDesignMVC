using SAMDesign.Abstractions.DataAccess.PRODUCTS.Add;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.PRODUCTS.Add
{
    public class ProductAdd_DA : IProductAdd_DA
    {
        private Context _Context;
        public ProductAdd_DA() 
        {
            _Context = new Context();
        }

        public async Task<int> Add(ProductsDTO product)
        {
            try
            {
                int cantAdd = 0;
                ProductsDA productDA = convert2DA(product);
                _Context.Products.Add(productDA);
                cantAdd = await _Context.SaveChangesAsync();
                return cantAdd;
            }
            catch (Exception ex)
            {
                throw new Exception ("Error adding product: " + ex.Message);
            }
        }

        private ProductsDA convert2DA (ProductsDTO product)
        {
            ProductsDA productDA = new ProductsDA()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
                comments = product.comments,
                UnitPrice = product.UnitPrice,
                img_path = product.img_path,
                statusID = product.statusID,
                created_by = product.created_by,
                created_on = product.created_on,
                modified_on = product.modified_on,
                modified_by = product.modified_by
            };
            return productDA;
        }
    }
}
