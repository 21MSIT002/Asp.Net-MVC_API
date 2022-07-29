using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using studentApi.Models;
using studentApi.Exceptionhandle;


namespace studentApi.Controllers
{
    public class StudController : ApiController
    {
        DBstudapiEntities s = new DBstudapiEntities();
        
        public List<STable> get()
        {
            var x = s.STables.ToList();
            return x;
        }

        
        [Route("namebase/{name}")]
        public List<STable> get(string name)
        {
            return s.STables.Where(a=>a.name == name).ToList();
            
        }

        public IHttpActionResult post([FromBody] STable st)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    st.total = st.sub1 + st.sub2 + st.sub3;
                    s.STables.Add(st);
                    s.SaveChanges();
                    return Ok(st);
                }
                else
                {

                    string error = " ";
                    if (ModelState.Values.ToArray()[0].Errors[0].ErrorMessage == " ")
                    {
                        error = ModelState.Values.ToArray()[0].Errors[0].Exception.Message;
                    }
                    else
                    {
                        error = ModelState.Values.ToArray()[0].Errors[0].ErrorMessage;
                    }
                    throw new customexception(error);

                }
            }
            catch(customexception cx)
            {
                return BadRequest(cx.Message);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        public IHttpActionResult put( [FromBody] STable st)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    s.Entry(st).State = EntityState.Modified;
                    st.total = st.sub1 + st.sub2 + st.sub3;
                    s.SaveChanges();
                    return Ok(st);
                }
                else
                {
                    string error = " ";
                    if (ModelState.Values.ToArray()[0].Errors[0].ErrorMessage == " ")
                    {
                        error = ModelState.Values.ToArray()[0].Errors[0].Exception.Message;
                    }
                    else
                    {
                        error = ModelState.Values.ToArray()[0].Errors[0].ErrorMessage;
                    }
                    throw new customexception(error);
                }
            }
            catch (customexception cx)
            {
                return BadRequest(cx.Message);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

                
        }
        public IHttpActionResult Delete(int id)
        {
            var x = s.STables.Where(a => a.id == id).FirstOrDefault();
            s.STables.Remove(x);
            s.SaveChanges();
            return Ok(x);
        }
    }
}
