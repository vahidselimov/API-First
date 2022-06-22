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
    public class CatagoryController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public CatagoryController(AplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            Category category = context.Categories.FirstOrDefault();
            return Ok(category);    



        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<Category> category =context.Categories.ToList();
            return Ok(category);

        }
        [HttpPost("create")]
        public IActionResult Create(Category category)
        {
           context.Categories.Add(category);
            context.SaveChanges();
            return Ok(category);



        }
        [HttpPut("update")]
        public IActionResult Update(Category category)
        {
            Category category1=context.Categories.FirstOrDefault(c=>c.Id==category.Id); 
            if(category1==null)return NotFound();
            category1.Name = category.Name;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            Category category=context.Categories.FirstOrDefault(c=>c.Id==id);
            if(category==null)return NotFound();
            context.Categories.Remove(category);
            return Ok();
        }
    }
}
