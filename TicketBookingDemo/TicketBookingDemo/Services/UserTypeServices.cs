using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketBookingDemo.Models;
using System.Data.Entity;

namespace TicketBookingDemo.Services
{
    public class UserTypeServices
    {
        private readonly EmployeeTicketBookingEntities dbContext; // Replace YourDbContext with your actual DbContext class

        public UserTypeService(EmployeeTicketBookingEntities context)
        {
            dbContext = context;
        }

        public UserType GetUserTypeById(int userTypeId)
        {
            return dbContext.UserTypes.FirstOrDefault(ut => ut.UserTypeId == userTypeId);
        }

        public List<UserType> GetAllUserTypes()
        {
            return dbContext.UserTypes.ToList();
        }

        // Other methods related to user type operations
    }
}