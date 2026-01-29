using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.CATEGORY.Edit
{
    public interface ICategoryEdit_BL
    {
        Task<int> Edit(CategoryDTO dTO);
    }
}
