using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
namespace SoHot_Data.Repositories
{
    public interface IBillRepository : IRepository<Bill>
    {
        // IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }

    public class OrderRepository : RepositoryBase<Bill>, IBillRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
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
