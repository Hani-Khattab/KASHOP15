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
    public class BrandsController : ControllerBase
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        [HttpGet("")]
        public IActionResult Index()
        {
            var brands = repo.Get();
            return Ok(brands);
        }


        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var brands = context.Brands.Find(id);
        //    return Ok(brands);
        //}

        //[HttpPost("")]
        //public IActionResult create(Brand brand)
        //{
        //    context.Brands.Add(brand);
        //    context.SaveChanges();
        //    return Ok();
        //}



    }
}