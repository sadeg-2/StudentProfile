using CMS.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using STD.Core.Dots.User;
using STD.Core.Dtos.Helpers;
using STD.Infrastructure.Services.Users;
using Result = STD.Core.Constants.Results;

namespace StudentProfile.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUserService userService) : base(userService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserDto input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.CreateAsync(input);
                }
                catch (Exception)
                {
                    return Ok(Result.AddFailResult());
                }
                return Ok(Result.AddSuccessResult());
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userService.GetAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateAsync(input);
                }
                catch (Exception)
                {
                    return Ok(Result.EditFailResult());
                }
                return Ok(Result.EditSuccessResult());

            }
            return View();
        }
        public async Task<JsonResult> GetUserData(Pagination pagination, Query query)
        {
            var result = await _userService.GetAll(pagination, query);
            return Json(result);
        }

        [HttpGet]
        public IActionResult getData()
        {
            var c = _userService.GetAllData();

            return Ok(c);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _userService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return Ok(Result.DeleteFailResult());
            }
            return Ok(Result.DeleteSuccessResult());
        }
    }
}
