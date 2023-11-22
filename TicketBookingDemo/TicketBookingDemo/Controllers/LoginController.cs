using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBookingDemo.Models;
using System.Data.Entity;
using TicketBookingDemo.Services;

namespace TicketBookingDemo.Controllers
{
    
    public class LoginController : Controller
    {
        //private EmployeeTicketBookingEntities db = new EmployeeTicketBookingEntities();
        //private readonly UserService userService;
        //// GET: Login
        //// public ActionResult LoginPage()
        ////{
        ////    return View();
        ////}

        ////[HttpPost]
        ////public ActionResult LoginPage(string adminid, string adminpassword)
        ////{
        ////    var user = db.AdminLogins.FirstOrDefault(u => u.AdminId == adminid && u.AdminPswd == adminpassword);

        ////    if (user != null)
        ////    {
        ////        // Redirect to dashboard or home page after successful login
        ////        return RedirectToAction("Index", "Home");
        ////    }
        ////    else
        ////    {
        ////        ViewBag.ErrorMessage = "Invalid username or password.";
        ////        return View();
        ////    }
        ////}

        //public LoginController()
        //{
        //    dbContext = new EmployeeTicketBookingEntities(); // Initialize your DbContext

        //    userService = new UserService(dbContext); // Initialize UserService
        //                                              // Initialize other services...
        //}

        //// Action to display the login view
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// POST action to handle user login
        //[HttpPost]
        //public ActionResult Index(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Validate user credentials (example: using UserService)
        //        var user = userService.AuthenticateUser(model.UserName, model.Password);
        //        if (user != null)
        //        {
        //            // User authenticated successfully, redirect to dashboard or desired page
        //            return RedirectToAction("Dashboard", "Home"); // Replace with your desired action and controller
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid credentials. Please try again.");
        //        }
        //    }
        //    return View(model); // Return to login view with errors
        //}

        //// Action to logout the user
        //public ActionResult Logout()
        //{
        //    // Perform logout actions, e.g., clear session, authentication tokens, etc.
        //    // Redirect to login page
        //    return RedirectToAction("Index");
        //}

        //.....................................................................................
        private readonly AuthenticationService authenticationService;
        private readonly EmployeeTicketBookingEntities dbContext;

        public LoginController()
        {
            // Initialize your authentication service
            dbContext = new EmployeeTicketBookingEntities(); // Initialize your DbContext
            authenticationService = new AuthenticationService(dbContext);
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password, string userType)
        {
            bool isAuthenticated = false;

            // Check the user type and verify credentials based on it
            switch (userType.ToLower())
            {
                case "admin":
                    isAuthenticated = authenticationService.VerifyAdminCredentials(username, password);
                    break;
                case "employee":
                    isAuthenticated = authenticationService.VerifyEmployeeCredentials(username, password);
                    break;
                case "manager":
                    isAuthenticated = authenticationService.VerifyManagerCredentials(username, password);
                    break;
                case "agent":
                    isAuthenticated = authenticationService.VerifyAgentCredentials(username, password);
                    break;
                default:
                    break;
            }

            if (isAuthenticated)
            {
                // Redirect to a respective dashboard or homepage based on user type
                switch (userType.ToLower())
                {
                    case "admin":
                        return RedirectToAction("AdminDashboard", "Admin");
                    case "employee":
                        return RedirectToAction("EmployeeDashboard", "Employee");
                    case "manager":
                        return RedirectToAction("ManagerDashboard", "Manager");
                    case "agent":
                        return RedirectToAction("AgentDashboard", "Agent");
                    default:
                        break;
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid credentials. Please try again.";
                return View();
            }
            ViewBag.ErrorMessage = "Invalid credentials or user type. Please try again.";
            return View();
        }
    }
}