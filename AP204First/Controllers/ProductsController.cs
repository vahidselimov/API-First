using AP204First.DAL;
using AP204First.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AP204First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public ProductsController(AplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GET/{id?}")]
        public IActionResult Get(int id)
        {
            Products products = context.Products.FirstOrDefault(p=>p.Id == id);
            if (products==null)
            {
                return NotFound();  

            }
            return Ok(products);

                
        }
        [HttpGet("all")]
        public IActionResult Getll()
        {
           List< Products> products = context.Products.ToList();
            return Ok(products);    
        }
        [HttpPost("Create")]
        public IActionResult Create(Products products)
        {
            if (products.Name.Length>5)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { title = "...." });
            }
            context.Products.Add(products);
            context.SaveChanges();
            return Ok(products);

        }
        [HttpPut("Upate")]
        public IActionResult Update(Products products)
        {
            Products products1 = context.Products.FirstOrDefault(p=>p.Id == products.Id);
            if (products1==null) return NotFound();
            products1.Name = products.Name; 
            products1.Price = products.Price;   
            context.SaveChanges();
            return Ok(products1);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            Products products1 = context.Products.Find(Id);  
            context.Products.Remove(products1); 
            return Ok(products1);
        }


    }
}
