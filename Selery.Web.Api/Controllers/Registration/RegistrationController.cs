using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using Selery.Web.Api.Models.Registration.Interface;
using Selery.BO.Entity.Registration;
using Selery.Model.Entity.Registration;

namespace Selery.Web.Api.Controllers.Registration
{
    public class RegistrationController : ApiController
    {
        private readonly IRegistration repository;

        public RegistrationController(IRegistration repository)
        {
            this.repository = repository;
        }

        [HttpPost, ActionName("adduser")]
        public HttpResponseMessage CreateUser(User user)
        {              
            User newUser = repository.CreateUser(user);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, newUser);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("/api/registration/getuserbyid/{0}", newUser.UserID.ToString()));
            return response;  
        }

        [HttpPost, ActionName("loginbyemail")]
        public User LoginByEmail(string email, [FromBody]  byte[] password)
        {            
            return repository.LoginByEmail(email, password);
        }

        [HttpPatch, ActionName("updateregistration")]
        public User UpdateUserRegistration([FromBody] User user)
        {

            return repository.UpdateUserRegistration(user);
        }

        [HttpPatch, ActionName("updateprofile")]
        public User UpdateUserProfile([FromBody] User user)
        {

            return repository.UpdateUserProfile(user);
        }

        [HttpGet, ActionName("finduserbyemail")]
        public int FindUserByEmail(string email)
        {
            return repository.FindUserByEmail(email);

        }

        [HttpGet, ActionName("finduserbyfacebookid")]
        public int FindUserByFacebookID(long facebookID)
        {
            return repository.FindUserByFacebookID(facebookID);

        }

        [HttpGet, ActionName("getuserbyemail")]
        public User SelectUserByEmail(string email)
        {
            User user = repository.SelectUserByEmail(email);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return user;
         
        }

        [HttpGet, ActionName("getuserbyid")]
        public User SelectUserByID(int id)
        {
            User user= repository.SelectUserByID(id);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));        
            }

            return user;
        }

        [HttpGet, ActionName("getuserbyfacebookid")]
        public User SelectUserByFacebookID(long facebookID)
        {
            User user = repository.SelectUserByFacebookID(facebookID);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return user;

        }

        [HttpGet, ActionName("selectactivity")]
        public IEnumerable<Activity> SelectActivity()
        {
            return repository.SelectActivity();
        }

        [HttpGet, ActionName("selectgoal")]
        public IEnumerable<Goal> SelectGoal()
        {
            return repository.SelectGoal();
        }

        [HttpPost, ActionName("userweightinsert")]
        public int UserWeightInsert(int userID,decimal weight,DateTime eventDate)
        {
            return repository.UserWeightInsert(userID, weight);
        }
    }
}
