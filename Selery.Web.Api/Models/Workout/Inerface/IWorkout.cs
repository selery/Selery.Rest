using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selery.Model.Entity.Workout;
using Selery.BO.Entity.Workout;


namespace Selery.Web.Api.Models.Workout.Interface
{
    public interface IWorkout
    {
        UserProgram SelectCurrentUserProgram(int UserID);
        IEnumerable<Program> SelectActivePrograms();
        IEnumerable<Program> UserAvailableProgramsSelect(int UserID);
        Program SelectProgram(int programID);
        int UsersInProgram(int programID);
        UserProgram UserProgramInsert(int userID, int programID);
        UserProgram UserProgramSelectByID(int userProgramID);
        int CheckUserProgramDay(int userID, DateTime date);
       

    }
}
