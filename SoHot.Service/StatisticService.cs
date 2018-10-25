using SoHot_Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot.Service
{
    public interface IStatisticService
    {
        //IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);

    }
    public class StatisticService : IStatisticService
    {
        IBillRepository _orderRepository;
        public StatisticService(IBillRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        //public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        //{
        //    return _orderRepository.GetRevenueStatistic(fromDate, toDate);
        //}
    }
}
