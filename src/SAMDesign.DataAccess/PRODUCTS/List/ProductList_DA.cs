using SAMDesign.Abstractions.DataAccess.PRODUCTS.List;
using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.PRODUCTS.List
{
    public class ProductList_DA : IProductList_DA
    {
        private Context _context;
        public ProductList_DA() 
        {
            _context = new Context();
        }
        public List<ProductsDTO> GetAdmin() 
        {
            List<ProductsDTO> products = (from p in _context.Products
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
                                      }).ToList();
            return products;
        }

        public List<ProductsDTO> Get()
        {
            List<ProductsDTO> products = (from p in _context.Products
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
                                          }).ToList();
            return products;
        }

    }
}
