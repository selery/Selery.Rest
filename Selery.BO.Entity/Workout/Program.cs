using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selery.BO.Entity.Workout
{
    public class Program
    {        
        public int ProgramID {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public string LongDescription { get; set; }
        public int ProgramStatusID {get;set;}
        public string ProgramStatusName {get;set;}
        public int GoalID { get; set; }
        public string GoalName {get;set;}
        public int Raiting { get; set; }
        public string ImageFile { get; set; }
		public int Duration { get; set; }
        public int UnitOfMeasureID { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string UnitOfMeasureDescription { get; set; }
    }
}
