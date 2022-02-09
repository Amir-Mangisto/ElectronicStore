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
    public class UsersController : ApiController
    {
        StoreDataContext DB = new StoreDataContext();

        // GET: api/Users
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DB.Users.ToList());
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

        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                User getUser = DB.Users.First(userItem => userItem.ID == id);
                if (getUser.UserFirstName != null)return Ok(getUser);
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

        // POST: api/Users
        public IHttpActionResult Post([FromBody]User addUser)
        {
            try
            {
                DB.Users.InsertOnSubmit(addUser);
                DB.SubmitChanges();
                return Ok("User was Added successfully");
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

        // PUT: api/Users/5
        public IHttpActionResult Put(int id, [FromBody]User updateUser)
        {
            try
            {
                User userUpdate=DB.Users.First(userItem => userItem.ID==id);
                userUpdate.ID = updateUser.ID;
                userUpdate.UserFirstName = updateUser.UserFirstName;
                userUpdate.UserLastName = updateUser.UserLastName;
                userUpdate.Mail=updateUser.Mail;
                userUpdate.Passwords=updateUser.Passwords;
                DB.SubmitChanges();
                return Ok("User was Updated successfully");
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

        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                User userToDelete = DB.Users.First(userItem => userItem.ID == id);
                DB.Users.DeleteOnSubmit(userToDelete);
                DB.SubmitChanges();
                return Ok("User was Deleted successfully");
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
