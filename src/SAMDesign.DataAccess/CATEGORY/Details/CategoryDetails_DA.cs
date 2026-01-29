using SAMDesign.Abstractions.DataAccess.CATEGORY.Details;
using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.CATEGORY.Details
{
    public class CategoryDetails_DA : ICategoryDetails_DA
    {
        private Context _context;
        public CategoryDetails_DA() 
        {
            _context = new Context();
        }

        public CategoryDTO Get(int categoryID)
        {
            CategoryDTO category = (from cat in _context.Categories
                                    where cat.categoryID == categoryID
                                    select new CategoryDTO
                                    {
                                        categoryID = cat.categoryID,
                                        categoryName = cat.categoryName,
                                        categoryDescription = cat.categoryDescription,
                                        status = cat.status,
                                        createdBy = cat.createdBy,
                                        createdOn = cat.createdOn,
                                        updatedBy = cat.updatedBy,
                                        updatedOn = cat.updatedOn
                                    }).FirstOrDefault();
            return category;
        }
    }
}
