using AutoMapper;
using STD.Core.ViewModels;
using STD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserDto, User>().
                ForMember(x => x.IdImageUrl, x => x.Ignore()).
                ForMember(x => x.PersonalImageUrl, x => x.Ignore());
            CreateMap<UpdateUserDto, User>().
               ForMember(x => x.IdImageUrl, x => x.Ignore()).
               ForMember(x => x.PersonalImageUrl, x => x.Ignore());
            CreateMap<User, UpdateUserDto>().
              ForMember(x => x.IdImageUrl, x => x.Ignore()).
              ForMember(x => x.PersonalImageUrl, x => x.Ignore());
            CreateMap<User, UserViewModel>().ForMember(x => x.id, x => x.MapFrom(x => x.IDNumber)).
                ForMember(x => x.Gender, x => x.MapFrom(x => x.Gender.ToString()));


            CreateMap<CreateStudentDto,Student>();
            CreateMap<UpdateStudentDto, Student>().ForMember(x => x.User, x => x.Ignore());
            CreateMap<Student, UpdateStudentDto>();
           
            CreateMap<Student, StudentViewModel>();

            CreateMap<User, ProfileViewModel>();

        }
    }
}
