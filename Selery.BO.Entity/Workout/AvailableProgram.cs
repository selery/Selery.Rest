using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selery.BO.Entity.Workout
{
    public class AvailableProgram : Program
    {
        public int UserID { get; set; }
        public Boolean? IsCurrent { get; set; }
    }
}
