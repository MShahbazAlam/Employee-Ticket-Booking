﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketBookingDemo.Models;
using System.Data.Entity;



namespace TicketBookingDemo.Services
{
    public class UserService
    {
        //    // Simulated data storage for users (replace this with database operations)
        private readonly List<User> _users = new List<User>();

        public UserService(EmployeeTicketBookingEntities context)
        {
            dbContext = context;
        }

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
                existingEmployee.Name = employee.Name;
                //--- existingEmployee.Name = employee.LastName;
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
        private readonly EmployeeTicketBookingEntities dbContext; // Replace YourDbContext with your DbContext class

        

        public User GetUserById(int userId)
        {
            return dbContext.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public List<User> GetAllUsers()
        {
            return dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var existingUser = dbContext.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                // Update other properties as needed
                dbContext.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (userToDelete != null)
            {
                dbContext.Users.Remove(userToDelete);
                dbContext.SaveChanges();
            }
        }

        // Other methods related to user operations
        //////////////
        ///
        public void AddTravelAgent(User agent)
        {
            _users.Add(agent);
        }

        public User GetTravelAgentById(int agentId)
        {
            return _users.Find(u => u.UserId == agentId && u.UserType == UserType.Agent);

        }

        public void UpdateTravelAgent(User agent)
        {
            // Your logic to update an employee in the data storage (e.g., database)
            var existingEmployee = _users.Find(u => u.UserId == agent.UserId);
            if (existingEmployee != null)
            {
                // Update properties of the existing employee
                existingEmployee.Name = agent.Name;
                //--- existingEmployee.LastName = agent.LastName;
                // Update other properties as needed
            }

            // Example: Your database update logic here
        }

        public List<User> GetAllTravelAgents()
        {
            // Your logic to retrieve all employees from the data storage (e.g., database)
            return _users.FindAll(u => u.UserType == UserType.Agent);
            // Example: Your database retrieval logic here
        }

        /////////////       Manager

        public List<Manager> GetAllManagers()
        {
            // Logic to retrieve all managers from the database
            return dbContext.Managers.ToList();
        }

        public Manager GetManagerById(int managerId)
        {
            // Logic to retrieve a manager by ID from the database
            return dbContext.Managers.FirstOrDefault(m => m.MgrId == managerId);
        }

        public void AddManager(Manager manager)
        {
            // Logic to add a new manager to the database
            dbContext.Managers.Add(manager);
            dbContext.SaveChanges();
        }

        public void UpdateManager(Manager manager)
        {
            // Logic to update an existing manager in the database
            dbContext.Entry(manager).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}