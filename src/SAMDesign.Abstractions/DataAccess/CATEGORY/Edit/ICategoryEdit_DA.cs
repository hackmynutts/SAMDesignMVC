using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.CATEGORY.Edit
{
    public interface ICategoryEdit_DA
    {
        Task<int> Edit(CategoryDTO categoryDTO);
    }
}
