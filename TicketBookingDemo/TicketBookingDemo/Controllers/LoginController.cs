using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBookingDemo.Models;
using System.Data.Entity;

namespace TicketBookingDemo.Controllers
{
    public class LoginController : Controller
    {
        private EmployeeTicketBookingEntities db = new EmployeeTicketBookingEntities();
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPage(string adminid, string adminpassword)
        {
            var user = db.AdminLogins.FirstOrDefault(u => u.AdminId == adminid && u.AdminPswd == adminpassword);

            if (user != null)
            {
                // Redirect to dashboard or home page after successful login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }
    }
}