using Microsoft.AspNetCore.Mvc;

namespace HukukTakipWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Kullanici") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }
    }
}