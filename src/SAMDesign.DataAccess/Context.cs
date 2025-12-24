using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer<Context>(null);
        }
    }
}
