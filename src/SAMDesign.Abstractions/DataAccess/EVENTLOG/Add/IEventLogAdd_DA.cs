using SAMDesign.Abstractions.UIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.Abstractions.DataAccess.EVENTLOG.Add
{
    public interface IEventLogAdd_DA
    {
        Task<int> Add(EventLogDTO log);
    }
}
