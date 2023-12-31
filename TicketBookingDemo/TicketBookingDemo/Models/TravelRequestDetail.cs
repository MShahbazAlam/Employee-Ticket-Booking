//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketBookingDemo.Models
{
    using System;
    using System.Collections.Generic;

    
    public partial class TravelRequestDetail 
    {
        public int RequestId { get; set; }
        public Nullable<int> EmpId { get; set; }
        public Nullable<int> EmpMgrId { get; set; }
        public string Destination { get; set; }
        public string Purpose { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public string TravelMode { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Manager Manager { get; set; }
        public string CurrentStatus { get; internal set; }
    }
}
