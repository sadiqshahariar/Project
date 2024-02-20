using FirstWebProject.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ILoginRepository _login;

        public UserController(ILoginRepository login)
        {

            _login = login;
        }

        public IActionResult Login(string message)
        {
            ViewBag.SuccessMessage = message;
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string email,string password)
        {
            //var successMessage = "";
            

            bool ans = _login.LoginUser(email,password);
            if (!ans)
            {
                //successMessage = "LoginFaild";
                return RedirectToAction("Login","User");
            }
            return RedirectToAction("Index", "Deshboard");

        }
    }
}
