using SAMDesign.Abstractions.DataAccess.CATEGORY.List;
using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.CATEGORY.List
{
    public class CategoryList_DA : ICategoryList_DA
    {
        private Context _context;
        public CategoryList_DA() 
        {
            _context = new Context();
        }

        public List<CategoryDTO> List()
        {
            List<CategoryDTO> categories = (from category in _context.Categories
                                            select new CategoryDTO
                                              {
                                                    categoryID = category.categoryID,
                                                    categoryName =  category.categoryName,
                                                    categoryDescription = category.categoryDescription,
                                                    status = category.status,
                                                    createdBy = category.createdBy,
                                                    createdOn = category.createdOn,
                                                    updatedBy = category.updatedBy,
                                                    updatedOn = category.updatedOn
                                              }).ToList();
            return categories;
        }

        public List<CategoryDTO> ListActive()
        {
            List<CategoryDTO> categories = (from category in _context.Categories
                                            where category.status == 13
                                            orderby category.createdOn descending
                                            select new CategoryDTO
                                            {
                                                categoryID = category.categoryID,
                                                categoryName = category.categoryName,
                                                categoryDescription = category.categoryDescription,
                                                status = category.status,
                                                createdBy = category.createdBy,
                                                createdOn = category.createdOn,
                                                updatedBy = category.updatedBy,
                                                updatedOn = category.updatedOn
                                            }).ToList();
            return categories;
        }
    }
}
