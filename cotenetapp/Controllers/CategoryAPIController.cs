using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cotenetapp.Models;
using cotenetapp.Services;

namespace cotenetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private readonly IServiceRepository<Category, int> repository;

        public CategoryAPIController(IServiceRepository<Category, int> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var cats = repository.GetAsync().Result;
            return Ok(cats);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cat = repository.GetAsync(id).Result;
            return Ok(cat);
        }
        [HttpPost]
        public IActionResult Post(Category cat)
        {
            if (ModelState.IsValid)
            {
                if (cat.BasePrice < 0) throw new Exception("Price cannot be -Ve");
                var res = repository.CreateAsync(cat).Result;
                return Ok(res); 
            }
            return BadRequest(cat);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Category cat)
        {
            if (ModelState.IsValid)
            {
                var res = repository.UpdateAsync(id, cat).Result;
                return Ok(res);
            }
            return BadRequest(cat);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Category cat)
        {
          var res = repository.DeleteAsync(id).Result;
                return Ok(res);
             
        }
    }
}