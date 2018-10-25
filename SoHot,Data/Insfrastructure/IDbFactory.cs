using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data.Insfrastructure
{
    public interface IDbFactory : IDisposable
    {
        SoHotDBContext Init();
    }
}
