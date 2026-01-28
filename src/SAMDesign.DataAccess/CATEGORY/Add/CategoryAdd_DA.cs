using SAMDesign.Abstractions.DataAccess.CATEGORY.Add;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.CATEGORY.Add
{
    public class CategoryAdd_DA : ICategoryAdd_DA
    {
        private Context _context;
        public CategoryAdd_DA() 
        {
            _context = new Context();
        }
        public async Task<int> Add(CategoryDTO category)
        {
            try
            {
                int cantAdd;
                CategoryDA categoryDA = convert2DA(category);
                _context.Categories.Add(categoryDA);
                cantAdd = await _context.SaveChangesAsync();
                return cantAdd;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding category: " + ex.Message);
            }

        }
        public CategoryDA convert2DA(CategoryDTO category) 
        {
            CategoryDA categoryDA = new CategoryDA()
                {
                categoryID = category.categoryID,
                categoryName = category.categoryName,
                categoryDescription = category.categoryDescription,
                status = category.status,
                createdBy = category.createdBy,
                createdOn = category.createdOn,
                updatedBy = category.updatedBy,
                updatedOn = category.updatedOn
            };
            return categoryDA;
        }
    }
}
