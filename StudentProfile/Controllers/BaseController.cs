using STD.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CMS.Web.Controllers
{
   [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUserService _userService;
        protected string userId;

        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = _userService.GetUserByUsernames(userName);
                userId = user.Id;
                ViewBag.image = user.IdImageUrl;
                //ViewBag.UserType = user.UserType.ToString();
            }
            ViewBag.UserType = "Administrator";

        }
    }
}
