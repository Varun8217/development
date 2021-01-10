using provisionStore1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProvisionStore.Controllers.API_Controllers
{
    public class userDetailsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetUserDetails([FromUri]int id)
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                return Ok((from b in entities.UserDetails
                           where b.UserID == id
                           select b).ToList());
            }
        }

        [HttpPost]
        public void PostUserDetails([FromUri]UserDetail userDetail)
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                entities.UserDetails.Add(userDetail);
                entities.SaveChanges();
            }
        }
    }
}
