using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STD.Core.Constant;
using STD.Core.Dots.User;
using STD.Core.Dtos;
using STD.Core.Dtos.Helpers;
using STD.Core.Enums;
using STD.Core.ViewModels;
using StudentProfile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Query = STD.Core.Dtos.Helpers.Query;

namespace STD.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;

        public UserService(
                ApplicationDbContext db,
                IMapper mapper,
                UserManager<User> userManager,
                IFileService fileService
                )
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
        }
        public async Task<User> CreateAsync(CreateUserDto dto)
        {
            var idExist = await _db.Users.AnyAsync(x => x.IDNumber == dto.IDNumber && !x.isDelete);
            if (idExist)
            {
                throw new Exception("");
            }
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.Email;
            user.Active = UserStatus.Active;
            user.TimeRegister = DateTime.Now;
            if (dto.IdImageUrl != null)
            {
                user.IdImageUrl = await _fileService.SaveFile(dto.IdImageUrl, FolderNames.ImagesFolder);
            }
            if (dto.PersonalImageUrl != null)
            {
                user.PersonalImageUrl = await _fileService.SaveFile(dto.PersonalImageUrl, FolderNames.ImagesFolder);
            }
            try
            {
                var result = await _userManager.CreateAsync(user, "Sadeg$2001");
                if (!result.Succeeded)
                {
                    throw new Exception();
                }
            }
            catch (Exception) { 
            }

            return user ;
        }
        public List<User> GetAllData()
        {
            var users = _db.Users.ToList();
            return users;
        }
        public async Task<string> DeleteAsync(string id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x=> x.IDNumber == id && !x.isDelete);
            if (user == null)
            {
                throw new Exception("");
            }
            user.isDelete = true;
            _db.Update(user);
            await _db.SaveChangesAsync();

            return user.IDNumber;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Users.Where(
            x => !x.isDelete && (
                x.FirstName.Contains(query.GeneralSearch)
                || x.FatherName.Contains(query.GeneralSearch)
                || x.GrandFatherName.Contains(query.GeneralSearch)
                || x.FamilyName.Contains(query.GeneralSearch)
                || string.IsNullOrWhiteSpace(query.GeneralSearch)
                )).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var users = _mapper.Map<List<UserViewModel>>(dataList);
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

        public async Task<UpdateUserDto> GetAsync(string id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.IDNumber == id && !x.isDelete);
            if(user == null)
            {
                throw new Exception("");
            }

            var userToUpdated = _mapper.Map<UpdateUserDto>(user);

            return userToUpdated;
        }

        public async Task<string> UpdateAsync(UpdateUserDto dto)
        {
            var idExist = await _db.Users.AnyAsync(x => x.IDNumber == dto.IDNumber && !x.isDelete);
            if (!idExist)
            {
                throw new Exception("");
            }
            var user = await _db.Users.FirstOrDefaultAsync(x=>x.IDNumber == dto.IDNumber);
            var updatedUSer = _mapper.Map<UpdateUserDto, User>(dto, user);

            if (dto.IdImageUrl != null)
            {
                updatedUSer.IdImageUrl = await _fileService.SaveFile(dto.IdImageUrl, FolderNames.ImagesFolder);
            }
            if (dto.PersonalImageUrl != null)
            {
                updatedUSer.PersonalImageUrl = await _fileService.SaveFile(dto.PersonalImageUrl, FolderNames.ImagesFolder);
            }
            _db.Users.Update(updatedUSer);
            await _db.SaveChangesAsync();
            return user.IDNumber;
        }
        public UserViewModel GetUserByUsername(string username)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserName == username && !x.isDelete);
            if (user == null)
            {
                throw new Exception();
            }
            return _mapper.Map<UserViewModel>(user);
        }

        public User GetUserByUsernames(string username)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserName == username && !x.isDelete);
            if (user == null)
            {
                throw new Exception();
            }
            return user;
        }



        public async Task<ProfileViewModel> GetUserById(string id) {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception();
            }

            return _mapper.Map<ProfileViewModel>(user);
        }
    }
}
