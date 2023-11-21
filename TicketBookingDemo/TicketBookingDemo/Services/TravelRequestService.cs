using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketBookingDemo.Models;
using System.Data.Entity;

namespace TicketBookingDemo.Services
{
    public class TravelRequestService
    {
        private readonly EmployeeTicketBookingEntities dbContext; // Replace YourDbContext with your actual DbContext class

        public TravelRequestService(EmployeeTicketBookingEntities context)
        {
            dbContext = context;
        }

        public TravelRequestDetail GetTravelRequestById(int requestId)
        {
            return dbContext.TravelRequestDetails.FirstOrDefault(tr => tr.RequestId == requestId);
        }

        public List<TravelRequestDetail> GetAllTravelRequests()
        {
            return dbContext.TravelRequestDetails.ToList();
        }

        public void UpdateTravelRequestStatus(int requestId, string newStatus)
        {
            var requestToUpdate = dbContext.TravelRequestDetails.FirstOrDefault(tr => tr.RequestId == requestId);
            if (requestToUpdate != null)
            {
                requestToUpdate.CurrentStatus = newStatus;
                dbContext.SaveChanges();
            }
        }

        // Other methods related to travel request operations
    }
}