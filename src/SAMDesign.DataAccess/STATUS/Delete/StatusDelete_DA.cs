using SAMDesign.Abstractions.DataAccess.STATUS.Delete;
using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess.STATUS.Delete
{
    public class StatusDelete_DA : IStatusDelete_DA
    {
        private Context _context;
        public StatusDelete_DA()
        {
            _context = new Context();
        }

        public async Task<bool> Delete(int id)
        {
            StatusDA status = (from s in _context.Statuses
                               where s.statusID == id
                               select s).FirstOrDefault();
            if (status != null)
            {
                _context.Statuses.Remove(status);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
