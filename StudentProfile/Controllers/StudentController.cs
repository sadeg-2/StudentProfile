using CMS.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using STD.Core.Dots.Student;
using STD.Core.Dots.User;
using STD.Core.Dtos.Helpers;
using STD.Infrastructure.Services.Students;
using STD.Infrastructure.Services.Users;
using Result = STD.Core.Constants.Results;

namespace StudentProfile.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        public StudentController(IUserService userService,IStudentService studentService) : base(userService)
        {
            _studentService = studentService;
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
        public async Task<IActionResult> Create([FromForm] CreateStudentDto input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _studentService.CreateAsync(input);
                }
                catch (Exception) {
                    return Ok(Result.AddFailResult());
                }
                return Ok(Result.AddSuccessResult());

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _studentService.GetAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateStudentDto input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _studentService.UpdateAsync(input);
                }
                catch (Exception) { 
                    return Ok(Result.EditFailResult());
                }
                return Ok(Result.EditSuccessResult());

            }
            return View();
        }
        public async Task<JsonResult> GetUserData(Pagination pagination, Query query)
        {
            var result = await _studentService.GetAll(pagination, query);
            return Json(result);
        }

        [HttpGet]
        public IActionResult getData()
        {
            var c = _studentService.GetAllData();

            return Ok(c);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return Ok(Result.DeleteFailResult());
            }
            return Ok(Result.DeleteSuccessResult());
        }
    }
}
