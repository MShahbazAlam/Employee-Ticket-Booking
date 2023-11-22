using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBookingDemo.Models;
using TicketBookingDemo.Services;

namespace TicketBookingDemo.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService userService;
        private readonly UserTypeServices userTypeService;
        private readonly TravelRequestService travelRequestService;
        private readonly EmployeeTicketBookingEntities dbContext;

        public AdminController()
        {
            dbContext = new EmployeeTicketBookingEntities(); // Initialize your DbContext

            userService = new UserService(dbContext);
            userTypeService = new UserTypeServices(dbContext);
            travelRequestService = new TravelRequestService(dbContext);
            // Assuming UserService handles user-related operations
        }

        // Action to display the Add Employee view
        public ActionResult AddEmployee()
        {
            // Your logic to prepare data for the view
            return View();
        }

        // POST action to handle adding a new employee
        [HttpPost]
        public ActionResult AddEmployee(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.AddEmployee(user); // Call service method to add employee
                    return RedirectToAction("EmployeeList"); // Redirect to employee list after successful addition
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error adding employee: " + ex.Message);
                }
            }
            return View(user);
        }

        // Action to display the Edit Employee view
        public ActionResult EditEmployee(int employeeId)
        {
            var employee = userService.GetEmployeeById(employeeId); // Fetch employee details by ID
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST action to handle editing an employee
        [HttpPost]
        public ActionResult EditEmployee(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.UpdateEmployee(user); // Call service method to update employee
                    return RedirectToAction("EmployeeList"); // Redirect to employee list after successful update
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error editing employee: " + ex.Message);
                }
            }
            return View(user);
        }

        // Action to display the list of employees
        public ActionResult EmployeeList()
        {
            var employees = userService.GetAllEmployees(); // Fetch all employees
            return View(employees);
        }

        // Action to display the Add Travel Agent view
        public ActionResult AddTravelAgent()
        {
            // Your logic to prepare data for the view
            return View();
        }

        // POST action to handle adding a new travel agent
        [HttpPost]
        public ActionResult AddTravelAgent(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.AddTravelAgent(user); // Call service method to add travel agent
                    return RedirectToAction("TravelAgentList"); // Redirect to travel agent list after successful addition
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error adding travel agent: " + ex.Message);
                }
            }
            return View(user);
        }

        // Action to display the Edit Travel Agent view
        public ActionResult EditTravelAgent(int agentId)
        {
            var agent = userService.GetTravelAgentById(agentId); // Fetch travel agent details by ID
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST action to handle editing a travel agent
        [HttpPost]
        public ActionResult EditTravelAgent(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.UpdateTravelAgent(user); // Call service method to update travel agent
                    return RedirectToAction("TravelAgentList"); // Redirect to travel agent list after successful update
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error editing travel agent: " + ex.Message);
                }
            }
            return View(user);
        }

        // Action to display the list of travel agents
        public ActionResult TravelAgentList()
        {
            var agents = userService.GetAllTravelAgents(); // Fetch all travel agents
            return View(agents);
        }
        public ActionResult Add()
        {
            // Your logic to prepare data for the view
            return View();
        }
    }
}