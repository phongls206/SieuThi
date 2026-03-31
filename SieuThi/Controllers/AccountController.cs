using Microsoft.AspNetCore.Mvc;
using SieuThi.Models;
namespace SieuThi.Controllers
{
    public class AccountController : Controller
    {
        static List<User> users = new List<User>();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
            {
                TempData["Success"] = "Đăng nhập thành công!";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Sai tài khoản!";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            var exist = users.FirstOrDefault(x => x.Username == username);

            if (exist != null)
            {
                ViewBag.Error = "Tài khoản đã tồn tại!";
                return View();
            }

            users.Add(new User { Username = username, Password = password });

            TempData["Success"] = "Tạo tài khoản thành công!";
            return RedirectToAction("Login");
        }

    }
}