using ASM_hungnqph19112_CS4.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASM_hungnqph19112_CS4.Controllers
{
    public class AuthController : Controller
    {
        private readonly DataContext _context;

        public AuthController()
        {
            _context = new DataContext();
        }
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserName") == null) 
                return View();
            return RedirectToAction("Index", "Home");
            
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var findUser = _context.Users.Where(x => x.Account.Equals(user.Account) && x.Password.Equals(user.Password))
                    .FirstOrDefault();
                if (findUser != null)
                {
                    HttpContext.Session.SetString("UserName", findUser.Account.ToString());
                    HttpContext.Session.SetString("Role", findUser.RoleId.ToString());
                    if(findUser.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    if(findUser.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            if((HttpContext.Session.GetString("UserName") != null))
            {
                HttpContext.Session.Remove("UserName");
                HttpContext.Session.Remove("Role");
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
