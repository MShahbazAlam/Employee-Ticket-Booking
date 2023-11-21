using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingDemo.Models
{
    public class UserType
    {
        public static UserType Employee { get; internal set; }
        public int UserTypeId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}