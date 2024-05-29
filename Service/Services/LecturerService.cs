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
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Data;


namespace MyProject.Service.Services
{
    public class LecturerService:IService<LecturerDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Lecturer> repository;
        public LecturerService(IRepository<Lecturer> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<LecturerDto> AddAsync(LecturerDto service)
        {


            return mapper.Map<LecturerDto>(await repository.AddItemAsync(mapper.Map<Lecturer>(service)));

        }



        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<List<LecturerDto>> GetAllAsync()
        {
            return mapper.Map<List<LecturerDto>>(await repository.GetAllAsync());
        }
 

        public async Task<LecturerDto> GetByIdAsync(int id)
        {
            return mapper.Map<LecturerDto>(await repository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(int id, LecturerDto service)
        {
            await repository.UpdateAsync(id, mapper.Map<Lecturer>(service));
        }
    }
}



