using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;

namespace SoHot_Data.Repositories
{
    public interface IFooterRepository : IRepository<Footer>
    {
    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}