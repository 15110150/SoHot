using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data.Repositories
{
    public interface IServiceRepository : IRepository<Service>
    {
    }

    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
