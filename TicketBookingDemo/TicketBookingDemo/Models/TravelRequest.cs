using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBookingDemo.Models
{
    public class TravelRequest
    {
        [Key]
        public int RequestId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime RequestDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string CurrentStatus { get; set; }
    }
}