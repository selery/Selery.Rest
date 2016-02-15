using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selery.BO.Entity.B2B
{
    public class Sponsor
    {
        public int SponsorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
    }

}
