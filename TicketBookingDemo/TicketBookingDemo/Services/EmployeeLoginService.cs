using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketBookingDemo.Models;

namespace TicketBookingDemo.Services
{
    public class EmployeeLoginService
    {
        private readonly EmployeeTicketBookingEntities dbContext;

        public EmployeeLoginService(EmployeeTicketBookingEntities context)
        {
            dbContext = context;
        }

        public bool IsValidEmployee(int empId, string username, string password)
        {
            // Check if the provided credentials match any employee in the database
            var employee = dbContext.EmployeeLogins.FirstOrDefault(e => e.EmpLoginId == empId  && e.EmpPswd == password);
            return employee != null;
        }
    }
}