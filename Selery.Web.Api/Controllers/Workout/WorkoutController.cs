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

       
        //rturns a workout program
        public Program Get(int id)
        {

            Program program = repository.SelectProgram(id);
            if (program == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return program;           

        }
                
        //all active workout programs
        public IEnumerable<Program> Get()
        {
            return repository.SelectActivePrograms();
        }

        /// <summary>
        /// returns all a vailable programs for user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet, ActionName("availableprograms")]
        public IEnumerable<Program> GetAvailablePrograms(int userID)
        {
            return  repository.UserAvailableProgramsSelect(userID);
            
        }

        /// <summary>
        /// Return current user program in progress
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet, ActionName("currentprogram")]
        public UserProgram GetCurrentUserProgram(int userID)
        {
            UserProgram program = repository.SelectCurrentUserProgram(userID);
            if(program==null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return program;

        }
        
        [HttpGet, ActionName("usersinprogram")]
        public int UsersInProgram(int programID)
        {
            return repository.UsersInProgram(programID);
        }

        [HttpPost, ActionName("setprogram")]
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
