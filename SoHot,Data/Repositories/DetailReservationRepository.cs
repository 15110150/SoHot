using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data.Repositories
{
    public interface IDetailReservationRepository : IRepository<DetailReservation>
    {
        // IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }

    public class DetailReservationRepository : RepositoryBase<DetailReservation>, IDetailReservationRepository
    {
        public DetailReservationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        //public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        //{
        //    var parameters = new SqlParameter[]{
        //        new SqlParameter("@fromDate",fromDate),
        //        new SqlParameter("@toDate",toDate)
        //    };
        //    return DbContext.Database.SqlQuery<RevenueStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters);
        //}
    }
}
