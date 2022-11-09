using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROD.Models
{
    public class CustModel
    {
        public int Customerid
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }

        [DataType(DataType.EmailAddress)] 
        public string Email
        {
            get;
            set;
        }
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }
        public int LoyaltyPoints
        {
            get;
            set;
        }
    }
   
}