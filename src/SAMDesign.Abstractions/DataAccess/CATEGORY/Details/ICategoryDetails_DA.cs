using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.CATEGORY.Details
{
    public interface ICategoryDetails_DA
    {
        CategoryDTO Get(int categoryID);
    }
}
