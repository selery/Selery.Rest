//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Selery.Model.Entity.Workout
{
    using System;
    
    public partial class spUserAvailableProgramsSelect_Result
    {
        public int ProgramID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int ProgramStatusID { get; set; }
        public string ProgramStatusName { get; set; }
        public int GoalID { get; set; }
        public string GoalName { get; set; }
        public Nullable<int> Raiting { get; set; }
        public string ImageFile { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<int> UnitOfMeasureID { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string UnitOfMeasureDescription { get; set; }
    }
}
