using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data.Insfrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SoHotDBContext dbContext;

        public SoHotDBContext Init()
        {
            return dbContext ?? (dbContext = new SoHotDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
