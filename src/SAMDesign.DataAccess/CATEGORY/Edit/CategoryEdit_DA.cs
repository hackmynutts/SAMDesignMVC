using SAMDesign.Abstractions.DataAccess.CATEGORY.Edit;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.CATEGORY.Edit
{
    public class CategoryEdit_DA : ICategoryEdit_DA
    {
        private Context _context;
        public CategoryEdit_DA() 
        {
            _context = new Context();
        }

        public async Task<int> Edit(CategoryDTO category)
        {
            int cant = 0;
            CategoryDA da = _context.Categories
                            .Where(c => c.categoryID == category.categoryID).FirstOrDefault();

            if (da != null)
            {
                da.categoryName = category.categoryName;
                da.categoryDescription = category.categoryDescription;
                da.status = category.status;
                da.updatedBy = category.updatedBy;
                da.updatedOn = category.updatedOn;
                cant = await _context.SaveChangesAsync();
            }
                return cant;
        }
    }
}
