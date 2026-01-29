using SAMDesign.Abstractions.BusinessLogic.CATEGORY.Details;
using SAMDesign.Abstractions.DataAccess.CATEGORY.Details;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.CATEGORY.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.CATEGORY.Details
{
    public class CategoryDetails_BL : ICategoryDetails_BL
    {
        private readonly ICategoryDetails_DA _categoryDetailsDA;
        public CategoryDetails_BL()
        {
            _categoryDetailsDA = new CategoryDetails_DA();
        }
        public CategoryDTO Get(int categoryID)
        {
            return _categoryDetailsDA.Get(categoryID);
        }
    }
}
