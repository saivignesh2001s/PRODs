using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Abstractions;

namespace PROD.Models
{
    public class CARRENT
    {
        public int RentId { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        
        public DateTime RentOrderDate { get; set; }
        public Nullable<int> OdoReading { get; set; }
        
        public Nullable<System.DateTime> ReturnDate { get; set; }

        public Nullable<int> ReturnOdoReading { get; set; }
        public string LicenseNumber
        {
            get;
            set;
        }


    }
    public class searchdates
    {

        [DataType(DataType.Date)]
        public DateTime RentDate
        {
            get;
            set;
        }
        [DataType(DataType.Date)]
        public DateTime ReturnDate
        {
            get;
            set;
        }
    }
}