using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using Selery.Web.Api.Models.Workout.Interface;
using Selery.BO.Entity.Workout;
using Selery.Model.Entity.Workout;


namespace Selery.Web.Api.Controllers.Workout
{
    public class WorkoutController : ApiController
    {
        private readonly IWorkout repository;

        public WorkoutController(IWorkout repository)
        {
            this.repository = repository;
        }

        [HttpGet, ActionName("getprogram")]
        public Program SelectProgram(int programID)
        {
            return repository.SelectProgram(programID);

        }

        [HttpGet, ActionName("getcurrentuserprogram")]
        public UserProgram SelectCurrentUserProgram(int userID)
        {
            return repository.SelectCurrentUserProgram(userID);

        }

        [HttpGet, ActionName("getactiveprograms")]
        public IEnumerable<Program> SelectActivePrograms()
        {
            return repository.SelectActivePrograms();
        }

        [HttpGet, ActionName("getavailableprograms")]
        public IEnumerable<Program> UserAvailableProgramsSelect(int userID)
        {
            return repository.UserAvailableProgramsSelect(userID);
        }

        [HttpGet, ActionName("getusersinprogram")]
        public int UsersInProgram(int programID)
        {
            return repository.UsersInProgram(programID);
        }

        [HttpPost, ActionName("userprograminsert")]
        public UserProgram UserProgramInsert(int userID, [FromBody]  Program program)
        {
            return repository.UserProgramInsert(userID, program.ProgramID);
        }

        [HttpPatch, ActionName("updateuserprogramday")]
        int CheckUserProgramDay(int userID, [FromBody] DateTime date)
        {
            return repository.CheckUserProgramDay(userID, date);
        }
    }
}
