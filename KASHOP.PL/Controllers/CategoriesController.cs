using KASHOP.BLL;
using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController (ICategoryService service) 
        {
            _service = service;
        }



        [HttpGet("")]
        public async Task <IActionResult> Index(CancellationToken cancellationToken) {

        var categories = await _service.GetAllAsync(cancellationToken);

          
            return Ok(categories);
        }


       // [HttpGet("{id}")]
       // public IActionResult GetById(int id) { 
        //var categories = context.Categories.Find(id);
          //  return Ok(categories);
        //}

        //[HttpPost("")]
        //public IActionResult create(Category category)
       // {
            //_repository.Create(category);
           // return Ok();
          
      //  }
    }
}
