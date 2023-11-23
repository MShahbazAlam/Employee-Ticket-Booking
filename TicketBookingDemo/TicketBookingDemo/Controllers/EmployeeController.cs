using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBookingDemo.Models;
using TicketBookingDemo.Services;


namespace TicketBookingDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult RequestTravel()
        {
            // Implement logic to prepare data for the view if needed
            return View();
        }

        [HttpPost]
        public ActionResult RequestTravel(TravelRequestDetail travelRequest)
        {
            if (ModelState.IsValid)
            {
                // Save the travel request to the database
                using (var dbContext = new EmployeeTicketBookingEntities())
                {
                    dbContext.TravelRequestDetails.Add(travelRequest);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("ViewRequests"); // Redirect to view requests page or another appropriate action
            }
            return View(travelRequest);
        }
    }
}