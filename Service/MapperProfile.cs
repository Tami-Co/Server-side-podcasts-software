using AutoMapper;
using Common.Dtos;
using MyProject.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {
            CreateMap<CategoryDto,Category>().ReverseMap();
            CreateMap< LectureDto, Lecture>().ReverseMap();
            CreateMap< LecturerDto,Lecturer>().ReverseMap();
            CreateMap<ResponseDto, Response>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();

        }
    }
}
