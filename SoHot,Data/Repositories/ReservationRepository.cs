using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
    }

    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}