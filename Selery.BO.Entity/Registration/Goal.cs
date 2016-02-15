using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selery.BO.Entity.Registration
{
	public class Goal
	{
		public int GoalID {get;set;}
        public string GoalName  {get;set;}
        public Boolean IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
	}
}

