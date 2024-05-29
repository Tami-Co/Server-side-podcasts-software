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
    public class ResponseService:IService<ResponseDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Response> repository;
        public ResponseService(IRepository<Response> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ResponseDto> AddAsync(ResponseDto service)
        {
            return mapper.Map<ResponseDto>(await repository.AddItemAsync(mapper.Map<Response>(service)));

        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<List<ResponseDto>> GetAllAsync()
        {
            return mapper.Map<List<ResponseDto>>(await repository.GetAllAsync());
        }

        public async Task<ResponseDto> GetByIdAsync(int id)
        {
            return mapper.Map<ResponseDto>(await repository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(int id, ResponseDto service)
        {
            await repository.UpdateAsync(id, mapper.Map<Response>(service));
        }
    }
}
