using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REPOSITORY.Models;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WEBAPI.Controller
{
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var products = db.Products.ToList();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(string id)
        {
            try
            {
                var product = db.Products.SingleOrDefault(p => p.Id == id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            try
            {
                db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                db.Remove(db.Products.Find(id));
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}