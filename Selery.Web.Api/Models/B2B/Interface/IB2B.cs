using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Selery.BO.Entity.B2B;

namespace Selery.Web.Api.Models.B2B.Interface
{
    public interface IB2B 
    {
        IEnumerable<Sponsor> GetSponsorByType(int sponsorTypeID);
    }
}
