//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarRent
    {
        public int RentId { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> RentOrderDate { get; set; }
        public Nullable<int> OdoReading { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<int> ReturnOdoReading { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
