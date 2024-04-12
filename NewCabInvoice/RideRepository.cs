using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCabInvoice
{
    public interface IRideRepository
    {
        IEnumerable<IRide> GetRidesForUser(int userId);
    }
    public class RideRepository : IRideRepository
    {
        private  Dictionary<int, List<IRide>> UserRides;

        public IEnumerable<IRide> GetRidesForUser(int userId)
        {
            UserRides = new Dictionary<int, List<IRide>>
            {
                {
                    123,
                    new List<IRide>
        {
            new Ride(10, 30), 
            new Ride(15, 45)  
        }
                }
            };
            if (UserRides.TryGetValue(userId, out List<IRide>? value))
            {
                return value;
            }

            return [];
        }
    }
}
