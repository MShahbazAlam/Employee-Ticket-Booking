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
    
    public partial class ManagerLogin
    {
        public Nullable<int> ManagerLoginId { get; set; }
        public string MgrPswd { get; set; }
    
        public virtual Manager Manager { get; set; }
    }
}
