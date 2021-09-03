using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Builderz.Data;
using Builderz.Models;

namespace Builderz.Controllers
{
    public class LoginsController : Controller
    {
        private readonly BuilderzContext _context;

        public LoginsController(BuilderzContext context)
        {
            _context = context;
        }

        // GET: Logins/Create

        public IActionResult LoginArea()
        {
            return View();
        }

        public IActionResult Erorr()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin([Bind("Id,UserName,Password")] Login login)
        {
            if(login.UserName == "Username" && login.Password == "Password")
            {
                return RedirectToAction("Admin", "Home");
            }
            else
            {
                return RedirectToAction(nameof(AdminLogin));
            }
        }
    }
}
