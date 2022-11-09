using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using PROD.Models;
using WebGrease.ImageAssemble;

namespace PROD.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDAL cd = null;
        CarDAL cdal = null;
        public CustomerController()
        {
            cd = new CustomerDAL();
            cdal= new CarDAL();
        }
        public ActionResult Register()
        {
            CustModel customer = new CustModel();
            customer.LoyaltyPoints = 0;
            return View(customer);
        }
        [HttpPost]
        public ActionResult Register(FormCollection c)
        {
            Customer c1 = new Customer();
            c1.LoyaltyPoints =Convert.ToInt32(c["LoyaltyPoints"]);
            c1.Customerid = Convert.ToInt32(c["Customerid"]);
            c1.CustomerName = c["CustomerName"].ToString();
            c1.mail = c["Email"].ToString();
            c1.Password = c["Password"].ToString();
            bool k=cd.AddCustomer(c1);
            if (k)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }


        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection c)
        {
            string s = c["Email"].ToString();
            string k = c["Password"].ToString();
            bool k1 = false;
            foreach(var item in cd.GetCustomers())
            {
               if(item.mail==s && item.Password == k)
                {
                    TempData["User"] = item;
                    k1 = true;
                } 
            }
            if (k1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid Credentials..Try Again";
                return View();
            }


        }

      
        // GET: Customer
        public ActionResult Index()
        {
          
                List<CAR> cars = new List<CAR>();

                List<Car> cs = cdal.getcar();
                foreach (Car c in cs)
                {
                    CAR cd = new CAR();
                    cd.Carid = c.Carid;
                    cd.Carname = c.Carname;
                    cd.PerDayCharge = c.PerDayCharge;
                    cd.ChargePerKm = c.ChargePerKm;
                    cd.CarType = c.CarType;
                    cars.Add(cd);
                }
            return View(cars);
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            Customer k = (Customer)TempData["User"];
            TempData["User"] = k;
            CustModel k1 = new CustModel();
            k1.Customerid = k.Customerid;
            k1.CustomerName = k.CustomerName;
            k1.Password = k.Password;
            k1.LoyaltyPoints =Convert.ToInt32(k.LoyaltyPoints);
            k1.Email = k.mail;
            return View(k1);
        }

      

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer k = cd.GetCustomer(id);
            CustModel k1 = new CustModel();
            k1.Customerid = k.Customerid;
            k1.CustomerName = k.CustomerName;
            k1.LoyaltyPoints = Convert.ToInt32(k.LoyaltyPoints);
            k1.Email = k.mail;
            

            return View(k1);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Customer k = new Customer();
            k.Customerid = Convert.ToInt32(collection["Customerid"]);
            k.CustomerName = collection["CustomerName"].ToString();
            k.mail = collection["Email"].ToString();
            k.LoyaltyPoints = Convert.ToInt32(collection["LoyaltyPoints"]);
         
           bool k1= cd.updatecustomer(id, k);
            if (k1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
