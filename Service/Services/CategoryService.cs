using AutoMapper;
using Common.Dtos;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Repository.Entity;
using MyProject.Repository.Interfaces;
using MyProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Services
{
    
    public class CategoryService : IService<CategoryDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Category> repository;
       public CategoryService(IRepository<Category> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto service)
        {
            
           return mapper.Map<CategoryDto>( await repository.AddItemAsync(mapper.Map<Category>(service)));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return mapper.Map<List<CategoryDto>>(await repository.GetAllAsync());
        }

        public async Task< CategoryDto> GetByIdAsync(int id)
        {
            return mapper.Map<CategoryDto>(await repository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(int id, CategoryDto service)
        {
            await repository.UpdateAsync(id, mapper.Map<Category>(service));
        }
    }
}
