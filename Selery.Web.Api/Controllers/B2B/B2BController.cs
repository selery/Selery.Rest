using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;

using Selery.Web.Api.Models.B2B.Interface;
using Selery.BO.Entity.B2B;
using Selery.Model.Entity.B2B;


namespace Selery.Web.Api.Controllers.B2B
{
    public class B2BController : ApiController
    {
        private readonly IB2B repository;

        public B2BController(IB2B repository)
        {
            this.repository = repository;
        }

        [HttpGet, ActionName("getsponsorbytype")]
        public IEnumerable<Sponsor> GetSponsorByType(int sponsorTypeID)
        {
            return repository.GetSponsorByType(sponsorTypeID);
        }        

    }
}
