using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingDemo.Models
{
    public class TravelRequest
    {
        public int RequestId { get; set; }

        [Required(ErrorMessage = "From Location is required")]
        [Display(Name = "From Location")]
        public string FromLocation { get; set; }

        [Required(ErrorMessage = "To Location is required")]
        [Display(Name = "To Location")]
        public string ToLocation { get; set; }

        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Departure Date is required")]
        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Return Date is required")]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "Purpose is required")]
        public string Purpose { get; set; }

        public int UserId { get; set; } // Reference to the User who made the request

        [Display(Name = "Current Status")]
        public string CurrentStatus { get; set; }

        // Additional properties as needed
    }
}