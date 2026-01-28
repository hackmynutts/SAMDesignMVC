using SAMDesign.Abstractions.BusinessLogic.CATEGORY.Add;
using SAMDesign.Abstractions.DataAccess.CATEGORY.Add;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.DataAccess.CATEGORY.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.CATEGORY.Add
{
    public class CategoryAdd_BL : ICategoryAdd_BL
    {
        private ICategoryAdd_DA _categoryAdd_DA;
        private readonly Idate _date;
        public CategoryAdd_BL()
        {
            _categoryAdd_DA = new CategoryAdd_DA();
            _date = new date();
        }

        public async Task<int> Add(CategoryDTO category)
        {
            category.createdOn = _date.GetDate();
            category.status = 13; // Active status
            int result = await _categoryAdd_DA.Add(category);
            return result;
        }
    }
}
