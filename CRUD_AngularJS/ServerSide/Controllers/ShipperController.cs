using ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ServerSide.Controllers
{
    public class ShipperController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();
        public IHttpActionResult GetShipper()
        {
            List<Shippers> shipperList = db.Shippers.ToList();
            return Json(shipperList);
        }

        [ResponseType(typeof(Shippers))]
        public IHttpActionResult GetShipper(int id)
        {
            Shippers shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(shipper);
            }
        }

        [ResponseType(typeof(Shippers))]
        public IHttpActionResult DeleteShipper(int id)
        {
            Shippers shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return NotFound();
            }
            else
            {
                db.Shippers.Remove(shipper);
                db.SaveChanges();
                return Json(db.Shippers.ToList());
            }
        }

        [ResponseType(typeof(Shippers))]
        public IHttpActionResult PutShipper(Shippers shipper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                db.Entry(shipper).State = System.Data.Entity.EntityState.Modified;
            }

            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {

            }

            return Json(db.Shippers.ToList());
        }

        [ResponseType(typeof(Shippers))]
        public IHttpActionResult PostShipper(Shippers shipper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
                return Json(db.Shippers.ToList());
            }
        }
    }
}
