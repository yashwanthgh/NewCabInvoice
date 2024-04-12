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
        private readonly Dictionary<int, List<IRide>> UserRides = [];

        public IEnumerable<IRide> GetRidesForUser(int userId)
        {
            if (UserRides.ContainsKey(userId))
            {
                return UserRides[userId];
            }
            return Enumerable.Empty<IRide>();
        }
    }
}
