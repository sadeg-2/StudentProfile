using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STD.Core.Dtos.Helpers;
using STD.Core.ViewModels;
using STD.Infrastructure.Services.Users;
using StudentProfile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Query = STD.Core.Dtos.Helpers.Query;

namespace STD.Infrastructure.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IUserService _userService;
        public StudentService(
                ApplicationDbContext db,
                IMapper mapper,
                IUserService userService,
                IFileService fileService
                )
        {
            _db = db;
            _mapper = mapper;
            _userService = userService;
            _fileService = fileService;
        }
        public async Task<Student> CreateAsync(CreateStudentDto dto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.IDNumber == dto.user.IDNumber && !x.isDelete);
            if (user == null)
            {
                user =  await _userService.CreateAsync(dto.user);
            }
            var student = _mapper.Map<Student>(dto);
            student.User.IdImageUrl = user.IdImageUrl;
            student.User.PersonalImageUrl = user.PersonalImageUrl;
            student.UserId = user.IDNumber;
            await _db.AddAsync(student);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex) { 
            
            }

            return student;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var student = await _db.Students.SingleOrDefaultAsync(x=> x.id == id && !x.isDelete);
            if (student == null)
            {
                throw new Exception("");
            }
            student.isDelete = true;
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
            return student.UserId;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Students.Include(x=> x.User).Where(
                        x => !x.isDelete && (
                        string.IsNullOrWhiteSpace(query.GeneralSearch)
                            )).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var users = _mapper.Map<List<StudentViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = users,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }

        public List<Student> GetAllData()
        {
            var students = _db.Students.Include(x=> x.User).ToList();

            return students;
        }

        public async Task<UpdateStudentDto> GetAsync(int id)
        {
            var student = await _db.Students.Include(x => x.User).SingleOrDefaultAsync(x => x.id == id && !x.isDelete);
            if (student == null)
            {
                throw new Exception("");
            }
            var updatedStudent = new UpdateStudentDto();
            try
            {
                 updatedStudent = _mapper.Map<UpdateStudentDto>(student);
            }
            catch (Exception ex) { 
            
            }
            return updatedStudent ;
        }

        public async Task<string> UpdateAsync(UpdateStudentDto dto)
        {
            var idExist = await _db.Students.Include(x => x.User).AnyAsync(x => x.id == dto.id && !x.isDelete);
            if (!idExist)
            {
                throw new Exception();
            }
            var student = await _db.Students.FindAsync(dto.id);
            var user = _userService.UpdateAsync(dto.user);
            var updatedStudent = _mapper.Map<UpdateStudentDto, Student>(dto,student);


            _db.Update(updatedStudent);
            try { _db.SaveChanges(); } catch (Exception) { };
            return student.UserId;
        }
    }
}
