using FirstWebProject.Models;
using FirstWebProject.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace FirstWebProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAccountRepository _account;

        public HomeController(IAccountRepository account)
        {

            _account = account;
        }
        public IActionResult Index(string id,string message)
        {
            ViewBag.SuccessMessage = message;

            List<User> users = _account.GetData();

            return View(users);
        }
        
        public async Task<IActionResult> SubmitForm(string username,string email,string phone,string password,DateOnly Dob)
        {
            var successMessage = "this from not add fully all data";
            if (!string.IsNullOrEmpty(email))
            {

                int ans = await _account.SaveUserDetails(username, email,phone,password,Dob);
                successMessage = "User Details Add Successfully.";
            }

            return RedirectToAction("Index", new { id = "1234",message = successMessage });

        }




        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddValue()
        {
            return View();
        }


        //delete

        [HttpPost]
        public IActionResult Delete(int userId)
        {
            // Assuming you're using Entity Framework Core to interact with the database
            bool delete = _account.isDelete(userId);

            // Redirect to a different action after deletion, or return a partial view, etc.
            return RedirectToAction("Index");
        }


        //Update
        //[HttpPost]
        public IActionResult Update(int userId)
        {
            return View(userId);
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateValue(int userId, string username, string email, string phone, DateOnly dob)
        {
            var successMessage = "Data Update Failed.";

            if (!string.IsNullOrEmpty(email))
            {
                // Find the user by userId
                bool isExistid = await _account.UpdateData(userId,username,email,phone,dob);


                if (isExistid)
                {
                    successMessage = "User details updated successfully.";
                }
            }

            return RedirectToAction("Index", new { id = userId, message = successMessage });
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
