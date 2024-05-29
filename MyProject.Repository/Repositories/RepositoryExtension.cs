using Microsoft.Extensions.DependencyInjection;
using MyProject.Repository.Entity;
using MyProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Repositories
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Category>), typeof(CategoryRepository));
            services.AddScoped(typeof(IRepository<Lecture>), typeof(LectureRepository));
            services.AddScoped(typeof(IRepository<Lecturer>), typeof(LecturerRepository));
            services.AddScoped(typeof(IRepository<Response>), typeof(ResponseRepository));
            services.AddScoped(typeof(IRepository<User>), typeof(UserRepository));
           // services.AddScoped(typeof(IRepository<UserLogin>), typeof(UserLoginRepository));
            return services;
        }
    }

}
