using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBookingDemo.Models;


namespace TicketBookingDemo.Controllers
{
    public class LoginController : Controller
    {
        
        private Employee_Ticket_BookingEntities db = new Employee_Ticket_BookingEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var user = db.Login.FirstOrDefault(u => u.Username == username && u.Password == password);

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