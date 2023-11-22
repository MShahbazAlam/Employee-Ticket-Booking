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
      //  private readonly ManagerService managerService;
        private readonly EmployeeTicketBookingEntities dbContext;
        public AdminController()
        {
            dbContext = new EmployeeTicketBookingEntities(); // Initialize your DbContext

            userService = new UserService(dbContext);
            userTypeService = new UserTypeServices(dbContext);
            travelRequestService = new TravelRequestService(dbContext);
          //  managerService = new ManagerService(dbContext);
            // Assuming UserService handles user-related operations
        }
        public ActionResult AdminDashboard()
        {
            return View();
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
        public ActionResult AddTravelAgent(TravelAgent travelAgent)
        {
            if (ModelState.IsValid)
            {
                // Add the travel agent data to the database
                using (var dbContext = new EmployeeTicketBookingEntities())
                {
                    dbContext.TravelAgents.Add(travelAgent);
                    dbContext.SaveChanges();
                }

                // Redirect to a success page or another action after adding the travel agent
                return RedirectToAction("TravelAgentList"); // Redirect to the list of travel agents or another appropriate action
            }

            // If ModelState is not valid, return the view with errors
            return View(travelAgent);
        }

        //public ActionResult AddTravelAgent(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            userService.AddTravelAgent(user); // Call service method to add travel agent
        //            return RedirectToAction("TravelAgentList"); // Redirect to travel agent list after successful addition
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Error adding travel agent: " + ex.Message);
        //        }
        //    }
        //    return View(user);
        //}

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
            //var agents = userService.GetAllTravelAgents(); // Fetch all travel agents
            //return View(agents);
            using (var dbContext = new EmployeeTicketBookingEntities())
            {
                var travelAgents = dbContext.TravelAgents.ToList();
                return View(travelAgents); // Return the list to the view
            }
        }

        // MAnager
        //public ActionResult AddManager()
        //{
        //    // Your logic to prepare data for the view
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddManager(Manager manager)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            managerService.AddManager(manager); // Call service method to add manager
        //            return RedirectToAction("ManagerList"); // Redirect to manager list after successful addition
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Error adding manager: " + ex.Message);
        //        }
        //    }
        //    return View(manager);
        //}

        //// Action to display the Edit Manager view
        //public ActionResult EditManager(int managerId)
        //{
        //    var manager = managerService.GetManagerById(managerId); // Fetch manager details by ID
        //    if (manager == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(manager);
        //}

        //// POST action to handle editing a manager
        //[HttpPost]
        //public ActionResult EditManager(Manager manager)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            managerService.UpdateManager(manager); // Call service method to update manager
        //            return RedirectToAction("ManagerList"); // Redirect to manager list after successful update
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Error editing manager: " + ex.Message);
        //        }
        //    }
        //    return View(manager);
        //}

        //public ActionResult ManagerList()
        //{
        //    var managers = managerService.GetAllManagers(); // Fetch all managers
        //    return View(managers);
        //}
        public ActionResult ManagerList()
        {
            var managers = userService.GetAllManagers(); // Fetch all managers
            return View(managers);
        }

        // Action to display the Add Manager view
        public ActionResult AddManager()
        {
            // Your logic to prepare data for the view
            return View();
        }

        // POST action to handle adding a new manager
        [HttpPost]
        public ActionResult AddManager(Manager manager)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.AddManager(manager); // Call UserService method to add manager
                    return RedirectToAction("ManagerList"); // Redirect to manager list after successful addition
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error adding manager: " + ex.Message);
                }
            }
            return View(manager);
        }

        // Action to display the Edit Manager view
        public ActionResult EditManager(int managerId)
        {
            var manager = userService.GetManagerById(managerId); // Fetch manager details by ID
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST action to handle editing a manager
        [HttpPost]
        public ActionResult EditManager(Manager manager)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.UpdateManager(manager); // Call UserService method to update manager
                    return RedirectToAction("ManagerList"); // Redirect to manager list after successful update
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error editing manager: " + ex.Message);
                }
            }
            return View(manager);
        }

    }
}