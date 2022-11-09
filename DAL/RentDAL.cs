using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RentDAL
    {
        CarRentalEntities context = null;
        public RentDAL()
        {
            context = new CarRentalEntities();

        }
            public bool rent(CarRent r)
            {
            try
            {
                context.CarRents.Add(r);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            }
            public void Return(int id, CarRent rent)
            {
                List<CarRent> rents = context.CarRents.ToList();
                CarRent r = rents.Find(x => x.RentId == id);
                context.CarRents.Remove(r);
                context.SaveChanges();
                context.CarRents.Add(rent);
                context.SaveChanges();

            }
            public CarRent find(int id)
            {
                List<CarRent> rents = context.CarRents.ToList();
                CarRent r = rents.Find(x => x.RentId == id);
                return r;
            }
           public  List<CarRent> rentlist()
        {
            return context.CarRents.ToList();
        }
        
    }
}
