using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Selery.Web.Api.Models.Registration.Interface;
using Selery.Model;
using Selery.Library.Common;
using Selery.Model.Entity.B2B;
using Selery.Web.Api.Models.B2B.Repository;
using Selery.Web.Api.Models.B2B.Interface;
using Selery.BO.Entity.B2B;


namespace Selery.Web.Api.Models.B2B.Repository
{
    public class B2BRepository : IB2B 
    {

        public IEnumerable<Sponsor> GetSponsorByType(int sponsoryTypeID)
        {
            List<Sponsor> sponsorList = new List<Sponsor>();
            IEnumerable<spSelectSponsorByType_Result> sponsorEFList;
            using (var context = new B2BEntities())
            {
                sponsorEFList = context.spSelectSponsorByType(sponsoryTypeID).ToList();
                foreach (spSelectSponsorByType_Result item in sponsorEFList)
                {
                    Sponsor sponsor = new Sponsor();
                    sponsor.Name = item.Name;
                    sponsor.SponsorID = item.SponsorID;
                    sponsor.Description = item.Description;
                    sponsor.TypeID = item.SponsorTypeID;
                    sponsor.TypeName = item.TypeName;
                    sponsorList.Add(sponsor);
                }
            }

            return sponsorList;
        }
    }
}
