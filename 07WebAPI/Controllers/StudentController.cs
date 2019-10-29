﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _07WebAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace _07webAPI_1.Controllers
{

    public class StudentController : ApiController
    {
        教務系統Entities db = new 教務系統Entities();
        // GET: api/Student
        public IEnumerable<學生> Get()
        {

            return db.學生;
        }

        // GET: api/Student/5
        public IHttpActionResult Get(string id)
        {
            var stu = db.學生.Find(id);//跟where方法依樣
            if (stu == null)
                return NotFound();
            return Ok(stu);
        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody]學生 stu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.學生.Add(stu);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (db.學生.Count(m => m.學號 == stu.學號) > 0)
                    return Conflict();
                else
                    throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = stu.學號 }, stu);
        }

        // PUT: api/Student/5
        public IHttpActionResult Put(string id, [FromBody]學生 stu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id!=stu.學號)
            {
                return BadRequest();
            }

            db.Entry(stu).State=EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (db.學生.Count(m => m.學號 == stu.學號) > 0)
                    return Conflict();
                else
                    throw;
            }
            //這邊可不寫,上面就要寫void
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(string id)
        {
            var stu = db.學生.Find(id);
            if (stu == null)
                return NotFound();
            db.學生.Remove(stu);
            db.SaveChanges();
            return Ok(stu);
        }
    }
}
