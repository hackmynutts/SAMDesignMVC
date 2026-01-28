using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.CATEGORY.Add
{
    public interface ICategoryAdd_DA
    {
        Task<int> Add(CategoryDTO category);
    }
}
