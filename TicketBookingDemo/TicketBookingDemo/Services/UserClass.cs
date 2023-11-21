using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketBookingDemo.Models;


namespace TicketBookingDemo.Services
{
    public class UserClass
    {
        // Simulated data storage for users (replace this with database operations)
        private readonly List<User> _users = new List<User>();

        // Method to add an employee
        public void AddEmployee(User employee)
        {
            // Your logic to add an employee to the data storage (e.g., database)
            _users.Add(employee);
            // Example: Your database insertion logic here
        }

        // Method to update an employee
        public void UpdateEmployee(User employee)
        {
            // Your logic to update an employee in the data storage (e.g., database)
            var existingEmployee = _users.Find(u => u.UserId == employee.UserId);
            if (existingEmployee != null)
            {
                // Update properties of the existing employee
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                // Update other properties as needed
            }
            // Example: Your database update logic here
        }

        // Method to get an employee by ID
        public User GetEmployeeById(int employeeId)
        {
            // Your logic to retrieve an employee by ID from the data storage (e.g., database)
            return _users.Find(u => u.UserId == employeeId && u.UserType == UserType.Employee);
            // Example: Your database retrieval logic here
        }

        // Method to get all employees
        public List<User> GetAllEmployees()
        {
            // Your logic to retrieve all employees from the data storage (e.g., database)
            return _users.FindAll(u => u.UserType == UserType.Employee);
            // Example: Your database retrieval logic here
        }

        // Similarly, implement methods for travel agents, managers, etc.
    }
}