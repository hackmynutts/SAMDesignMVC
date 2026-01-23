using SAMDesign.Abstractions.BusinessLogic.CATEGORY.List;
using SAMDesign.Abstractions.DataAccess.CATEGORY.List;
using SAMDesign.Abstractions.UIModules;
using SAMDesign.DataAccess.CATEGORY.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.BusinessLogic.CATEGORY.List
{
    public class CategoryList_BL : ICategoryList_BL
    {
        private readonly ICategoryList_DA _categoryListDA;
        public CategoryList_BL()
        {
            _categoryListDA = new CategoryList_DA();
        }

        public List<CategoryDTO> List()
        {
            return _categoryListDA.List();
        }


    }
}
