using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.BusinessLogic.EVENTLOGS.Add
{
    public interface IEventLogAdd_BL
    {
        Task<int> Add(EventLogDTO log);
    }
}
