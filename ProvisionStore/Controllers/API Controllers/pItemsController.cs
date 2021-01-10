using provisionStore1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProvisionStore.Controllers.API_Controllers
{
    public class PItemsController : ApiController
    {
       
        public IHttpActionResult Get()
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                return Ok((from b in entities.Products1

                           select b).ToList());
            }
        }
        [HttpGet]
        public IHttpActionResult GetUpdate([FromUri]int id)
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())

            {
                return Ok((from b in entities.Products1
                           where b.productId == id

                          select b ).ToList());
            }
        }
        [HttpPut]
        public IHttpActionResult UpdateItems(int id, [FromUri]Product1 product)
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                var entity = entities.Products1.FirstOrDefault(e => e.productId == id);
                entity.ProductName = product.ProductName;
                entity.Price = product.Price;
                entity.quantity = product.quantity;
                entity.total = product.total;
                entities.SaveChanges();
                return Ok();

            }
        }

        [HttpDelete]
        public void DeleteItem([FromUri]int id)
        {
            using (billGeneratorEntities entities = new billGeneratorEntities())
            {
                entities.Products1.Remove(entities.Products1.FirstOrDefault(e => e.productId == id));
                entities.SaveChanges();
            }
        }

    }
}
