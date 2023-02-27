using CI_Platform_web.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CI_Platform_web.Entities.DataModels;

namespace CI_Platform_web.Controllers
{
    public class PagesController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            UserLoginModel _userLoginModel = new UserLoginModel();
            return View(_userLoginModel);
        }

        [HttpPost]
        public IActionResult Index(UserLoginModel _userLoginModel)
        {
            userDbContext _userDbContext = new userDbContext();
            var status = _userDbContext.Users.Where(m => m.Email == _userLoginModel.Email && m.Password == _userLoginModel.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("Login", "Pages");
            }

            return View(_userLoginModel);
        }

        public IActionResult Login()
        {
            return View()
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
