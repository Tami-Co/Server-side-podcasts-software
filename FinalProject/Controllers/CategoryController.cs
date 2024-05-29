using Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using MyProject.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<CategoryDto> service;
        public CategoryController(IService<CategoryDto> service)
        {
            this.service = service;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task< List<CategoryDto>> Get()
        {
            var categories= await service.GetAllAsync();
            foreach(var category in categories)
            {
                category.UrlImage=GetImage(category.UrlImage);
            }
            return categories;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task< CategoryDto> Get(int id)
        {
            var category= await service.GetByIdAsync(id);
            category.UrlImage=GetImage(category.UrlImage);
            return category;
        }

        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Images/", ImageUrl);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(bytes);
            string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            return image;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromForm] CategoryDto categoryDto)
        {

            var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + categoryDto.FileImage.FileName);
            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                categoryDto.FileImage.CopyTo(fs);
                fs.Close();
            }
            categoryDto.UrlImage = categoryDto.FileImage.FileName;
            await service.AddAsync(categoryDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] CategoryDto value)

        {
            var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + value.FileImage.FileName);
            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                value.FileImage.CopyTo(fs);
                fs.Close();
            }
            value.UrlImage = value.FileImage.FileName;
            await service.UpdateAsync(id, value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
          await  service.DeleteAsync(id);
        }
    }
}
