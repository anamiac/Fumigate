//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fumigate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TicketGrid
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public int Author { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string Title { get; set; }
        public Nullable<int> Priority { get; set; }
        public int ID { get; set; }
        public int Version { get; set; }
        public int Expr1 { get; set; }
        public int ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public Nullable<int> Status { get; set; }
        public int AssignedTo { get; set; }
        public string Comment { get; set; }
    }
}