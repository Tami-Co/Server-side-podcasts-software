using Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using MyProject.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly IService<LecturerDto> service;
        public LecturerController(IService<LecturerDto> service)
        {
            this.service = service;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<LecturerDto>> Get()
        {
            return await service.GetAllAsync();
        }
        [HttpGet("MaxViews")]
        public async Task<IActionResult> GetMaxViews()
        {
            var lecturers = await service.GetAllAsync();
            var maxViews = lecturers.OrderByDescending(l => l.NumberViews).Take(6);
            return Ok(new { success = true, data = maxViews });
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<LecturerDto> Get(int id)
        {
            return await service.GetByIdAsync(id);
        }

        //[HttpGet("getImage/{ImageUrl}")]
        //public string GetImage(string ImageUrl)
        //{
        //    var path=Path.Combine(Environment.CurrentDirectory, "Images/",ImageUrl);
        //    byte[] bytes=System.IO.File.ReadAllBytes(path);
        //    string imageBase64=Convert.ToBase64String(bytes);
        //    string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
        //    return image;
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromBody] LecturerDto lecturerDto)
        {
          
            await service.AddAsync(lecturerDto);
        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] LecturerDto value)
        {
            await service.UpdateAsync(id, value);
        }
      

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
