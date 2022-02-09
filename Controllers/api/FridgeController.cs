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
    public class FridgeController : ApiController
    {
        StoreDataContext DB = new StoreDataContext();

        // GET: api/Fridge
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DB.Fridges.ToList());
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

        // GET: api/Fridge/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Fridge getFridge = DB.Fridges.First(fridgeItem => fridgeItem.Id == id);
                if (getFridge.ProductName != null) return Ok(getFridge);
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

        // POST: api/Fridge
        public IHttpActionResult Post([FromBody] Fridge addFridge)
        {
            try
            {
                DB.Fridges.InsertOnSubmit(addFridge);
                DB.SubmitChanges();
                return Ok("Fridge was Added successfully");
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

        // PUT: api/Fridge/5
        public IHttpActionResult Put(int id, [FromBody] Fridge updateFridge)
        {
            try
            {
                Fridge fridge = DB.Fridges.First(fridgeItem => fridgeItem.Id == id);
                fridge.Id=updateFridge.Id;
                fridge.ProductName=updateFridge.ProductName;
                fridge.Company=updateFridge.Company;
                fridge.Brand=updateFridge.Brand;
                fridge.Price=updateFridge.Price;
                fridge.Photo=updateFridge.Photo;
                DB.SubmitChanges();
                return Ok("Fridge was Updated successfully");
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

        // DELETE: api/Fridge/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Fridge fridgeToDelete = DB.Fridges.First(fridgeItem => fridgeItem.Id == id);
                DB.Fridges.DeleteOnSubmit(fridgeToDelete);
                DB.SubmitChanges();
                return Ok("Fridge was Deleted successfully");
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
