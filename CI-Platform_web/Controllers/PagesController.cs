using CI_Platform_web.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CI_Platform_web.Entities.DataModels;

namespace CI_Platform_web.Controllers
{
    public class PagesController : Controller
    {
        private readonly CIDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public PagesController(ILogger<HomeController> logger, CIDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext; 
        }
        [HttpGet]
              
        public IActionResult Login()
        {
            UserLoginModel _userLoginModel = new UserLoginModel();
            return View(_userLoginModel);

        }
        [HttpPost]
        public IActionResult Login(UserLoginModel _userLoginModel)
        {
            var status = _dbContext.Users.Where(m => m.Email == _userLoginModel.Email && m.Password == _userLoginModel.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View(_userLoginModel);
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
