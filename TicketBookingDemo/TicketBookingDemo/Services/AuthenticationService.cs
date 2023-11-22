using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketBookingDemo.Models;
using System.Data.Entity;

namespace TicketBookingDemo.Services
{
    public class AuthenticationService
    {
        private readonly EmployeeTicketBookingEntities dbContext;

        public AuthenticationService(EmployeeTicketBookingEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool VerifyAdminCredentials(string adminId, string adminPassword)
        {
            var admin = dbContext.AdminLogins.FirstOrDefault(a => a.AdminId == adminId && a.AdminPswd == adminPassword);
            return admin != null;
        }

        public bool VerifyEmployeeCredentials(string employeeId, string employeePassword)
        {
            var employee = dbContext.EmployeeLogins.FirstOrDefault(e => e.EmpLoginId.ToString() == employeeId && e.EmpPswd.ToString() == employeePassword);
            return employee != null;
        }

        public bool VerifyManagerCredentials(string managerId, string managerPassword)
        {
            var manager = dbContext.ManagerLogins.FirstOrDefault(m => m.ManagerLoginId.ToString() == managerId && m.MgrPswd == managerPassword);
            return manager != null;
        }

        public bool VerifyAgentCredentials(string agentId, string agentPassword)
        {
            var agent = dbContext.TravelAgentLogins.FirstOrDefault(a => a.AgentLoginId.ToString() == agentId && a.AgentPswd == agentPassword);
            return agent != null;
        }
    }

}