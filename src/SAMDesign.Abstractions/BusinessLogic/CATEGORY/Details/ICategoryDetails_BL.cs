using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.CATEGORY.Details
{
    public interface ICategoryDetails_BL
    {
        CategoryDTO Get(int categoryID);
    }
}
