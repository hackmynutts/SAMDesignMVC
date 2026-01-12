using SAMDesign.Abstractions.DataAccess.PRODUCTS.Details;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.PRODUCTS.Details
{
    public class ProductDetails_DA : IProductDetails_DA
    {
        private Context _Context;
        public ProductDetails_DA()
        {
            _Context = new Context();
        }

        public ProductsDTO Get(int id)
        {
            ProductsDTO product = (from p in _Context.Products
                                    where p.ProductID == id
                                    select new ProductsDTO
                                          {
                                              ProductID = p.ProductID,
                                              ProductName = p.ProductName,
                                              CategoryID = p.CategoryID,
                                              comments = p.comments,
                                              UnitPrice = p.UnitPrice,
                                              img_path = p.img_path,
                                              statusID = p.statusID,
                                              created_by = p.created_by,
                                              created_on = p.created_on,
                                              modified_on = p.modified_on,
                                              modified_by = p.modified_by
                                          }).FirstOrDefault();
            return product;
        }
    }
}
