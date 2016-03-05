using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selery.Web.Api.Models.Workout.Interface;
using Selery.Model;
using Selery.Model.Entity.Workout;
using Selery.BO.Entity.Workout;
using Selery.Library.Common;


namespace Selery.Web.Api.Models.Workout.Repository
{
    public class WorkoutRepository: IWorkout
    {
        public WorkoutRepository()
        { }

        public Program SelectProgram(int programID)
        {
            Program program = null;
            using (var context = new WorkoutEntities())
            {
                spSelectProgramByID_Result programEF = context.spSelectProgramByID(programID).FirstOrDefault();
                if (programEF != null)
                {
                    program = new Program();
                    program.ProgramID = programEF.ProgramID;
                    program.Name = programEF.Name;
                    program.Description = programEF.Description;
                    program.LongDescription = programEF.LongDescription;
                    program.ProgramStatusID = programEF.ProgramStatusID;
                    program.ProgramStatusName = programEF.ProgramStatusName;
                    program.GoalID = programEF.GoalID;
                    program.GoalName = programEF.GoalName;
                    program.Raiting = programEF.Raiting.HasValue ? programEF.Raiting.Value : 0;
                    program.ImageFile = programEF.ImageFile;
                    program.Duration = programEF.Duration.HasValue ? programEF.Duration.Value : 0;
                    program.UnitOfMeasureID = programEF.UnitOfMeasureID.HasValue ? programEF.UnitOfMeasureID.Value : 0;
                    program.UnitOfMeasureCode = programEF.UnitOfMeasureCode;
                    program.UnitOfMeasureDescription = programEF.UnitOfMeasureDescription;
                }
            }

            return program;
        }

        public UserProgram UserProgramSelectByID(int userProgramID)
        {
            UserProgram userProgram = null;

            using (var context = new WorkoutEntities())
            {
                spSelectUserProgramByID_Result userProgramEF = context.spSelectUserProgramByID(userProgramID).FirstOrDefault();
                if (userProgramEF != null)
                {
                    userProgram = new UserProgram();
                    userProgram.ProgramID = userProgramEF.ProgramID;
                    userProgram.Name = userProgramEF.Name;
                    userProgram.Description = userProgramEF.Description;
                    userProgram.LongDescription = userProgramEF.LongDescription;
                    userProgram.ProgramStatusID = userProgramEF.ProgramStatusID;
                    userProgram.ProgramStatusName = userProgramEF.ProgramStatusName;
                    userProgram.GoalID = userProgramEF.GoalID;
                    userProgram.GoalName = userProgramEF.GoalName;
                    userProgram.Raiting = userProgramEF.Raiting.HasValue ? userProgramEF.Raiting.Value : 0;
                    userProgram.ImageFile = userProgramEF.ImageFile;
                    userProgram.IsCompleted = userProgramEF.IsCompleted;
                    userProgram.StartDate = userProgramEF.StartDate.HasValue ? userProgramEF.StartDate.Value : DateTime.MinValue;
                    userProgram.EndDate = userProgramEF.EndDate.HasValue ? userProgramEF.EndDate.Value : DateTime.MinValue;
                    userProgram.OnProgress = userProgramEF.OnProgress.HasValue ? userProgramEF.OnProgress.Value : false;
                    userProgram.CreatedDate = userProgramEF.CreatedDate;
                    userProgram.Duration = userProgramEF.Duration.HasValue ? userProgramEF.Duration.Value : 0;
                    userProgram.UnitOfMeasureID = userProgramEF.UnitOfMeasureID.HasValue ? userProgramEF.UnitOfMeasureID.Value : 0;
                    userProgram.UnitOfMeasureCode = userProgramEF.UnitOfMeasureCode;
                    userProgram.UnitOfMeasureDescription = userProgramEF.UnitOfMeasureDescription;
                    userProgram.CurrentDay = userProgramEF.CurrentDay.HasValue ? userProgramEF.CurrentDay.Value : 0;
                    userProgram.BMIStart = userProgramEF.BMIStart.HasValue ? userProgramEF.BMIStart.Value : 0;                    
                }
               
            }

            return userProgram;

        }

        public UserProgram SelectCurrentUserProgram(int userID)
        {
            UserProgram userProgram = null;

            using (var context = new WorkoutEntities())
            {
                spSelectCurrentUserProgram_Result userProgramEF = context.spSelectCurrentUserProgram(userID).FirstOrDefault();
              
               if (userProgramEF != null)
               {
                   userProgram = new UserProgram();              
                   userProgram.ProgramID = userProgramEF.ProgramID;
                   userProgram.Name = userProgramEF.Name;
                   userProgram.Description = userProgramEF.Description;
                   userProgram.LongDescription = userProgramEF.LongDescription;
                   userProgram.ProgramStatusID = userProgramEF.ProgramStatusID;
                   userProgram.ProgramStatusName = userProgramEF.ProgramStatusName;
                   userProgram.GoalID = userProgramEF.GoalID;
                   userProgram.GoalName = userProgramEF.GoalName;
                   userProgram.Raiting = userProgramEF.Raiting.HasValue ? userProgramEF.Raiting.Value : 0;
                   userProgram.ImageFile = userProgramEF.ImageFile;
                   userProgram.IsCompleted = userProgramEF.IsCompleted;
                   userProgram.StartDate = userProgramEF.StartDate.HasValue ? userProgramEF.StartDate.Value : DateTime.MinValue;
                   userProgram.EndDate = userProgramEF.EndDate.HasValue ? userProgramEF.EndDate.Value : DateTime.MinValue;
                   userProgram.OnProgress = userProgramEF.OnProgress.HasValue ? userProgramEF.OnProgress.Value : false;
                   userProgram.CreatedDate = userProgramEF.CreatedDate;
                   userProgram.Duration = userProgramEF.Duration.HasValue ? userProgramEF.Duration.Value : 0;
                   userProgram.UnitOfMeasureID = userProgramEF.UnitOfMeasureID.HasValue ? userProgramEF.UnitOfMeasureID.Value : 0;
                   userProgram.UnitOfMeasureCode = userProgramEF.UnitOfMeasureCode;
                   userProgram.UnitOfMeasureDescription = userProgramEF.UnitOfMeasureDescription;
                   userProgram.CurrentDay = userProgramEF.CurrentDay.HasValue ? userProgramEF.CurrentDay.Value : 0;
                   userProgram.BMIStart = userProgramEF.BMIStart.HasValue ? userProgramEF.BMIStart.Value:0;
               }

            }

            return userProgram;
        }

        public IEnumerable<Program> SelectActivePrograms()
        {
            List<Program> listPrograms = new List<Program>();
            IEnumerable<spSelectActivePrograms_Result> listEF;

            using (var context = new WorkoutEntities())
            {
                listEF = context.spSelectActivePrograms().ToList();
            }

            foreach (spSelectActivePrograms_Result item in listEF)
            {
                Program program = new Program();
                program.GoalID = item.GoalID;
                program.GoalName = item.GoalName;
                program.Name = item.Name;
                program.Description = item.Description;
                program.LongDescription = item.LongDescription;
                program.ProgramID = item.ProgramID;                
                program.ProgramStatusID = item.ProgramStatusID;
                program.ProgramStatusName = item.ProgramStatusName;
                program.Raiting = item.Raiting.HasValue? item.Raiting.Value:0 ;
                program.ImageFile = item.ImageFile;
                program.Duration = item.Duration.HasValue ? item.Duration.Value : 0;
                program.UnitOfMeasureID = item.UnitOfMeasureID.HasValue ? item.UnitOfMeasureID.Value : 0;
                program.UnitOfMeasureCode = item.UnitOfMeasureCode;
                program.UnitOfMeasureDescription = item.UnitOfMeasureDescription;
                listPrograms.Add(program);
            }

            return listPrograms;
        }

        public IEnumerable<AvailableProgram> UserAvailableProgramsSelect(int UserID)
        {
            List<AvailableProgram> programs = new List<AvailableProgram>();
            IEnumerable<spUserAvailableProgramsSelect_Result> listEF;

            using (var context = new WorkoutEntities())
            {
                listEF = context.spUserAvailableProgramsSelect(UserID).ToList();
            }

            foreach (spUserAvailableProgramsSelect_Result item in listEF)
            {
                AvailableProgram program = new AvailableProgram();
                program.GoalID = item.GoalID;
                program.GoalName = item.GoalName;
                program.Name = item.Name;
                program.Description = item.Description;
                program.LongDescription = item.LongDescription;
                program.ProgramID = item.ProgramID;
                program.ProgramStatusID = item.ProgramStatusID;
                program.ProgramStatusName = item.ProgramStatusName;
                program.Raiting = item.Raiting.HasValue ? item.Raiting.Value : 0;
                program.ImageFile = item.ImageFile;
                program.Duration = item.Duration.HasValue ? item.Duration.Value : 0;
                program.UnitOfMeasureID = item.UnitOfMeasureID.HasValue ? item.UnitOfMeasureID.Value : 0;
                program.UnitOfMeasureCode = item.UnitOfMeasureCode;
                program.UnitOfMeasureDescription = item.UnitOfMeasureDescription;
                program.UsersInProgram = item.UsersInProgram.Value;
                program.IsCurrent = item.IsCurrent;
                programs.Add(program);
            }

            return programs;
        }

        public int UsersInProgram(int programID)
        {
            using (var context = new WorkoutEntities())
            {
                return (context.spUsersInPorgram(programID).FirstOrDefault()).UsersInProgram.Value;
            }
        }

        public UserProgram UserProgramInsert(int userID, int programID)
        {
            spUserProgramInsert_Result retVal;

            using (var context = new WorkoutEntities())
            {

                context.spUserProgramCurrentReset(userID);

                retVal = context.spUserProgramInsert(userID, programID).FirstOrDefault();

                context.spUserProgramDayExericeInsert(userID, programID);
            }

            return UserProgramSelectByID(Convert.ToInt32(retVal.UserProgramXRefID.Value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="date"></param>
        /// <returns>
        /// 0: el cliente va en el mismo dia que el servidor
        /// entero positivo >0 : el cliente va mas adelante que el servidor
        /// -1: el cliente ya supero la fecha de finalizacion del programa
        /// </returns>
        /// <remarks>
        /// </remarks>
        public int CheckUserProgramDay(int userID, DateTime date)
        {
            int retVal = 0;
            //obtener lafecha de inicio del programa
            UserProgram userProgram = this.SelectCurrentUserProgram(userID);           

            //de acuerdo a la fehca del cliente, calcular en que dia va el usuario
            int userCurrentDay = (date.Date - userProgram.StartDate.Date).Days +1;

            //checar si han pasado mas dias de los dias que tiene el programa
            if (userCurrentDay > userProgram.Duration)
            { 
                retVal= -1;
            }
            //si el dia del programa no es igual al dia del usuario
            //actualizar el programa con el dia en el que va el usuario
            else if (userCurrentDay > userProgram.CurrentDay)
            {
                using (var context = new WorkoutEntities())
                {
                    int? rowcount = context.spUserProgramUpdateCurrentDay(userID, userProgram.ProgramID, userCurrentDay).SingleOrDefault();
                }
                retVal = userCurrentDay;
            }

            return retVal;
        }
    }
}
