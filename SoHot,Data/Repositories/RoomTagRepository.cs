using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;

namespace SoHot_Data.Repositories
{
    public interface IRoomTagRepository : IRepository<RoomTag>
    {
    }

    public class RoomTagRepository : RepositoryBase<RoomTag>, IRoomTagRepository
    {
        public RoomTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}