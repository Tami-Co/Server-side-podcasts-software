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
    public class LectureService:IService<LectureDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Lecture> repository;
        public LectureService(IRepository<Lecture> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<LectureDto> AddAsync(LectureDto service)
        {
            return mapper.Map<LectureDto>(await repository.AddItemAsync(mapper.Map<Lecture>(service)));

        }



        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<List<LectureDto>> GetAllAsync()
        {
            return mapper.Map<List<LectureDto>>(await repository.GetAllAsync());
        }

        public async Task<LectureDto> GetByIdAsync(int id)
        {
            return mapper.Map<LectureDto>(await repository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(int id, LectureDto service)
        {
            await repository.UpdateAsync(id, mapper.Map<Lecture>(service));
        }
    }
}
