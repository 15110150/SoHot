using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data.Repositories
{
    public interface IRoomTypeRepository : IRepository<RoomType>
    {
        IEnumerable<RoomType> GetByAlias(string alias);
    }

    public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<RoomType> GetByAlias(string alias)
        {
            return this.DbContext.RoomTypes.Where(x => x.Alias == alias);
        }


    }
}
