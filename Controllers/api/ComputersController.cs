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
    public class ComputersController : ApiController
    {
        StoreDataContext DB = new StoreDataContext();
        // GET: api/Computers
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DB.Computers.ToList());
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

        // GET: api/Computers/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Computer getComputer = DB.Computers.First(computerItem => computerItem.ID == id);
                if (getComputer.ProductName != null) return Ok(getComputer);
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

        // POST: api/Computers
        public IHttpActionResult Post([FromBody] Computer addComputer)
        {
            try
            {
                DB.Computers.InsertOnSubmit(addComputer);
                DB.SubmitChanges();
                return Ok("Computer was Added successfully");
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

        // PUT: api/Computers/5
        public IHttpActionResult Put(int id, [FromBody] Computer updateComputre)
        {
            try
            {
                Computer computer = DB.Computers.First(computerItem => computerItem.ID == id);
                computer.ID=updateComputre.ID;
                computer.ProductName=updateComputre.ProductName;
                computer.Company=updateComputre.Company;
                computer.Brand=updateComputre.Brand;
                computer.Price=updateComputre.Price;
                computer.Photo=updateComputre.Photo;
                DB.SubmitChanges();
                return Ok("Computer was Updated successfully");
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

        // DELETE: api/Computers/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Computer computerToDelete = DB.Computers.First(computerItem => computerItem.ID == id);
                DB.Computers.DeleteOnSubmit(computerToDelete);
                DB.SubmitChanges();
                return Ok("Computer was Deleted successfully");
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
