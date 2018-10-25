using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data.Repositories
{
    public interface IRoomServiceRepository : IRepository<RoomService>
    {
    }

    public class RoomServiceRepository : RepositoryBase<RoomService>, IRoomServiceRepository
    {
        public RoomServiceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
