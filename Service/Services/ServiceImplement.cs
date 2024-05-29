using Common.Dtos;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Repository;
using MyProject.Repository.Repositories;
using MyProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Services
{
    public static class ServiceImplement
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped(typeof(IService<CategoryDto>), typeof(CategoryService));
            services.AddScoped(typeof(IService<LectureDto>), typeof(LectureService));
            services.AddScoped(typeof(IService<LecturerDto>), typeof(LecturerService));
            services.AddScoped(typeof(IService<ResponseDto>), typeof(ResponseService));
            services.AddScoped(typeof(IServicesExtention<UserDto>), typeof(UserService));
            services.AddAutoMapper(typeof(MapperProfile));
            return services;

        }
     }
 }

