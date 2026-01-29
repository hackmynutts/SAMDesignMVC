using SAMDesign.Abstractions.BusinessLogic.CATEGORY.Edit;
using SAMDesign.Abstractions.DataAccess.CATEGORY.Edit;
using SAMDesign.Abstractions.general.DateManagement;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.BusinessLogic.general.DateManagement;
using SAMDesign.DataAccess.CATEGORY.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.CATEGORY.Edit
{
    public class CategoryEdit_BL : ICategoryEdit_BL
    {
        private readonly Idate IDate;
        private readonly ICategoryEdit_DA _categoryEditDA;
        public CategoryEdit_BL()
        {
            IDate = new date();
            _categoryEditDA = new CategoryEdit_DA();
        }

        public async Task<int> Edit(CategoryDTO dTO)
        {
            dTO.updatedOn = IDate.GetDate();
            int result = await _categoryEditDA.Edit(dTO);
            return result;  
        }
    }
}
