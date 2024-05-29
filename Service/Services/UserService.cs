using AutoMapper;
using Common.Dtos;
using MyProject.Repository.Entity;
using MyProject.Repository.Interfaces;
using MyProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Services
{
    public class UserService:IServicesExtention<UserDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;
        public UserService(IRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UserDto> AddAsync(UserDto service)
        {
            return mapper.Map<UserDto>(await repository.AddItemAsync(mapper.Map<User>(service)));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return mapper.Map<List<UserDto>>(await repository.GetAllAsync());
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            return mapper.Map<UserDto>(await repository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(int id, UserDto service)
        {
            await repository.UpdateAsync(id, mapper.Map<User>(service));
        }
        public async Task<string> GetUserByUserEmail(string userEmail, string password)
        {
            var lst = await repository.GetAllAsync();
            foreach (var item in lst)
            {
                if (item.Email == userEmail)
                {
                    if (item.Password == password)
                        return item.Id.ToString();
                    else
                        return "password";
                }
            }
            return "email";

        }
       

    }
}
