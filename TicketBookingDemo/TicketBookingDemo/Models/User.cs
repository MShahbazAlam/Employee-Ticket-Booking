using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingDemo.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "User Type is required")]
        public UserType UserType { get; set; } 

    }
}