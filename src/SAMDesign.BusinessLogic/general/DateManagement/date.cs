using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using SAMDesign.Abstractions.general.DateManagement;

namespace SAMDesign.BusinessLogic.general.DateManagement
{
    public class date : Idate
    {
        public DateTime GetDate()
        {
            int zonaHoraria = int.Parse(ConfigurationManager.AppSettings["zonaHoraria"]);
            return DateTime.UtcNow.AddHours(zonaHoraria);
        }
    }
}
