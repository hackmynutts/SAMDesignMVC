using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.CATEGORY.List
{
    public interface ICategoryList_DA
    {
        List<CategoryDTO> List();
    }
}
