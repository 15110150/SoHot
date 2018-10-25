using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data.Repositories
{
    // khai báo IProductrepository mà trong RepositoryBase ko có 
    public interface IRoomRepository : IRepository<Room>
    {
        IEnumerable<Room> GetListRoomByTag(string tagId, int page, int pageSize, out int totalRow);
        IEnumerable<Room> GetListRoomAvailable (int roomTypeID, DateTime checkIn, DateTime checkOut);
        int NummberOfRoomIsAvailable(int roomTypeID, DateTime checkIn, DateTime checkOut);

    }

    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        //kế thừa constructor
        public RoomRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        // triển khai IProductrepository

        public IEnumerable<Room> GetListRoomByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Rooms
                        join pt in DbContext.RoomTags
                        on p.ID equals pt.RoomID
                        where pt.TagID == tagId
                        select p;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IEnumerable<Room> GetListRoomAvailable(int roomTypeID, DateTime checkIn, DateTime checkOut)
        {
            var query = from p in DbContext.Rooms
                        where p.RoomTypeID == roomTypeID
                        && !(from pt in DbContext.Reservations join ptt in DbContext.DetailReservations
                             on pt.ID equals ptt.ReservationID
                             where (pt.CheckInDateTime <= checkIn && pt.CheckOutDateTime >= checkIn)
                             || (pt.CheckInDateTime < checkOut && pt.CheckOutDateTime >= checkOut)
                             || (checkIn <= pt.CheckInDateTime && checkOut >= pt.CheckInDateTime)
                             select ptt.RoomID
                             ).Contains(p.ID)
                        select p;
            return query;
        }
        public int NummberOfRoomIsAvailable(int roomTypeID, DateTime checkIn, DateTime checkOut)
        {
            var quey = GetListRoomAvailable(roomTypeID,  checkIn, checkOut);
            
            return quey.Count();
        
        }
    }
}
