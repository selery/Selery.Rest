﻿using System;
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

        #region Gets
        public RegistrationController(IRegistration repository)
        {
            this.repository = repository;
        }

        public User Get(int id)
        {
            User user = repository.SelectUserByID(id);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return user;
        }

        public User GetUserByEmail(string email)
        {
            User user = repository.SelectUserByEmail(email);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return user;

        }

        public User GetUserByFacebookID(long facebookID)
        {
            User user = repository.SelectUserByFacebookID(facebookID);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return user;

        }
        
        public IEnumerable<User> Get([FromUri]User user)
        {
            return null;
        }

       
        #endregion

        #region Posts
        public HttpResponseMessage Post(User user)
        {
            User newUser = repository.CreateUser(user);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, newUser);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("/api/registration/{0}", newUser.UserID.ToString()));
            return response;
        }

        [HttpPost, ActionName("login")]
        public HttpResponseMessage PostLogin(Credentials credentials)
        {
            User result = repository.LoginByEmail(credentials.Email, credentials.Password);
            if (result == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Request.CreateResponse<User>(HttpStatusCode.OK, result);
        }

        #endregion
        /*       

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
         **/
    }
}
