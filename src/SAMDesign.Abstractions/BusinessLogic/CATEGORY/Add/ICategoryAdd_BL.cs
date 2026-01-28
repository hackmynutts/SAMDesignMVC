using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.CATEGORY.Add
{
    public interface ICategoryAdd_BL
    {
        Task<int> Add(CategoryDTO category);
    }
}
