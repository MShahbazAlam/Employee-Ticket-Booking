﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmployeeTicketBookingEntities : DbContext
    {
        public EmployeeTicketBookingEntities()
            : base("name=EmployeeTicketBookingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<RequestStatu> RequestStatus { get; set; }
        public virtual DbSet<TravelAgent> TravelAgents { get; set; }
        public virtual DbSet<TravelRequestDetail> TravelRequestDetails { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<EmployeeLogin> EmployeeLogins { get; set; }
        public virtual DbSet<ManagerLogin> ManagerLogins { get; set; }
        public virtual DbSet<TravelAgentLogin> TravelAgentLogins { get; set; }
    }
}
