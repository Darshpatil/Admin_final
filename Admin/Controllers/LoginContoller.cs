/*using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class LoginContoller : Controller
    {
        [AllowAnonymous] // Allow access without authentication for the login action
        public IActionResult Login()
        {
            return View();

        }

        [AllowAnonymous] // Allow access without authentication for the login action
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Check the credentials (you should use a more secure authentication mechanism)
            if (model.Username == "yourUsername" && model.Password == "yourPassword")
            {
                // For simplicity, use session to store the authentication status
                HttpContext.Session.SetString("IsAuthenticated", "true");

                return RedirectToAction("Index");
            }

            // Invalid credentials, show error
            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public IActionResult Logout()
        {
            // Clear the authentication status
            HttpContext.Session.Remove("IsAuthenticated");
            return RedirectToAction("Login");
        }
    }
}
*/