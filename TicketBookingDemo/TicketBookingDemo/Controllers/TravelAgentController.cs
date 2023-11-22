using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TicketBookingDemo.Models;

using TicketBookingDemo.Controllers;

namespace TicketBookingDemo.Controllers
{
    public class TravelAgentController : Controller
    {


        private EmployeeTicketBookingEntities db = new EmployeeTicketBookingEntities(); // Replace YourDbContext with your actual DbContext

        // GET: TravelAgent
        public ActionResult Index()
        {
            // Get a list of pending travel requests to be confirmed by the travel agent
            var pendingRequests = db.RequestStatus.Where(tr => tr.TravelAgentStatus == "Pending").ToList();
            return View(pendingRequests);
        }

        // POST: TravelAgent/ConfirmRequest/5
        [HttpPost]
        public ActionResult ConfirmRequest(int requestId)
        {
            var request = db.RequestStatus.Find(requestId);
            if (request == null)
            {
                return HttpNotFound();
            }

            // Perform logic to confirm the travel request
            request.TravelAgentStatus = "Ticket Confirmed";

            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: TravelAgent/RejectRequest/5
        [HttpPost]
        public ActionResult RejectRequest(int requestId)
        {
            var request = db.RequestStatus.Find(requestId);
            if (request == null)
            {
                return HttpNotFound();
            }

            // Perform logic to reject the travel request
            request.TravelAgentStatus = "No Availability";

            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult Index()
        //{
        //    return View();

        //}
    }
}