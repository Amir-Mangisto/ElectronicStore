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
    public class TvController : ApiController
    {
        StoreDataContext DB = new StoreDataContext();

        // GET: api/Tv
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DB.Tvs.ToList());
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

        // GET: api/Tv/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Tv getTv = DB.Tvs.First((tvItem) => tvItem.Id == id);
                if (getTv.ProductName != null) return Ok(getTv);
                else { return NotFound(); }
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

        // POST: api/Tv
        public IHttpActionResult Post([FromBody]Tv addTv)
        {
            try
            {
                DB.Tvs.InsertOnSubmit(addTv);
                DB.SubmitChanges();
                return Ok("Tv was Added successfully");
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

        // PUT: api/Tv/5
        public IHttpActionResult Put(int id, [FromBody]Tv updateTv)
        {
            try
            {
                Tv tvToUpdate = DB.Tvs.First(tvItem => tvItem.Id == id);
                tvToUpdate.Id= updateTv.Id;
                tvToUpdate.ProductName= updateTv.ProductName;
                tvToUpdate.Company= updateTv.Company;
                tvToUpdate.Brand= updateTv.Brand;
                tvToUpdate.Price= updateTv.Price;
                tvToUpdate.Size= updateTv.Size;
                tvToUpdate.Photo= updateTv.Photo;
                DB.SubmitChanges();
                return Ok("Tv was updated successfully");
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

        // DELETE: api/Tv/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Tv tvToDelete = DB.Tvs.First(tvItem => tvItem.Id == id);
                DB.Tvs.DeleteOnSubmit(tvToDelete);
                DB.SubmitChanges();
                return Ok("Tv was deleted successfully");
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
