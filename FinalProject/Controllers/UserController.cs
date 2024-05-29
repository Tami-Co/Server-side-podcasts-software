using Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using MyProject.Repository.Interfaces;
using MyProject.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IServicesExtention<UserDto> service;

        public UserController(IServicesExtention<UserDto> service)
        {
            this.service = service;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await service.GetAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            var user= await service.GetByIdAsync(id);
            user.Password = "****";
            return user;
        }

      
        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromBody] UserDto userDto)
        {
            await service.AddAsync(userDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDto value)
        {
            await service.UpdateAsync(id, value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> GetByUserEmail([FromBody] UserDto user)
        {
            string res = await service.GetUserByUserEmail(user.Email, user.Password);
            if (res == "email")
                return Ok("worng");
            else
            if (res == "password")
                return Ok("worng");
            return Ok(res);
        }

        [HttpGet("CheckUserIsExist/{userEmail}")]
        public async Task<bool> CheckUserIsExist(string userEmail)
        {
            var lst = await service.GetAllAsync();
            foreach (var item in lst)
            {
                if (item.Email == userEmail)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
