using Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using MyProject.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IService<ResponseDto> service;
        public ResponseController(IService<ResponseDto> service)
        {
            this.service = service;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<ResponseDto>> Get()
        {
            return await service.GetAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            return await service.GetByIdAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromForm] ResponseDto responserDto)
        {
            await service.AddAsync(responserDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ResponseDto value)
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
