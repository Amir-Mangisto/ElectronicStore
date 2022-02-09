using ElectronicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElectronicStore.Controllers.api
{
    public class PhonsController : ApiController
    {
        StoreDataContext DB = new StoreDataContext();

        // GET: api/Phons
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DB.Phons.ToList());
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // GET: api/Phons/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Phon getPhone = DB.Phons.First(phoneItem => phoneItem.ID == id);
                if (getPhone.ProductName != null) return Ok(getPhone);
                else { return NotFound();}
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // POST: api/Phons
        public IHttpActionResult Post([FromBody]Phon addPhone)
        {
            try
            {
                DB.Phons.InsertOnSubmit(addPhone);
                DB.SubmitChanges();
                return Ok("Phone was Added successfully");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/Phons/5
        public IHttpActionResult Put(int id, [FromBody]Phon updatePhone)
        {
            try
            {
                Phon phonToUpdate = DB.Phons.First(phoneItem => phoneItem.ID == id);
                phonToUpdate.ID = updatePhone.ID;
                phonToUpdate.ProductName = updatePhone.ProductName;
                phonToUpdate.Company=updatePhone.Company;
                phonToUpdate.Brand = updatePhone.Brand;
                phonToUpdate.Price = updatePhone.Price;
                phonToUpdate.Photo = updatePhone.Photo;
                DB.SubmitChanges();
                return Ok("Phone was Updated successfully");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // DELETE: api/Phons/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Phon phonToDelete = DB.Phons.First(phoneItem => phoneItem.ID == id);
                DB.Phons.DeleteOnSubmit(phonToDelete);
                DB.SubmitChanges();
                return Ok("Phone was Updated successfully");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
