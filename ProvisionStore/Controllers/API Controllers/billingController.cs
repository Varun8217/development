using provisionStore1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProvisionStore.Controllers
{
    public class billingController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                return Ok((from b in entities.products

                           select b).ToList());
            }
        }
       

        public void Post([FromUri]Product1 product1)
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                entities.Products1.Add(product1);
                entities.SaveChanges();
            }
        }
        [HttpDelete]
        public void Delete()
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                entities.Products1.RemoveRange(entities.Products1);
                entities.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteItem(int id)
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                entities.Products1.Remove(entities.Products1.FirstOrDefault(e => e.productId == id));
                entities.SaveChanges();
            }
        }
    }
}
