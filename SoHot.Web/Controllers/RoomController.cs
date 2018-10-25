using AutoMapper;
using SoHot.Model.Models;
using SoHot.Service;
using SoHot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace SoHot.Web.Controllers
{
    public class RoomController : Controller
    {
       
        IRoomService _roomService;
        IRoomTypeService _roomTypeService;
        public RoomController(IRoomService roomService, IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
        }
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(int id)
        {
            var roomModel = _roomService.GetListRoomByCategory(id);
            var roomViewModel = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(roomModel);
         
            return View(roomViewModel);
        }
        public ActionResult AvailableRoom(FormCollection Fields)
        {
            if (Fields != null)
            {
                int maxPeople = Convert.ToInt32(Fields["people"]);
                string checkIn2 = Convert.ToString(Fields["dateCheckIn"]);
                DateTime checkIn = Convert.ToDateTime(Fields["dateCheckIn"]);
                DateTime checkOut = Convert.ToDateTime(Fields["dateCheckOut"]);
                TempData["checkIn"] = checkIn;
                TempData["checkOut"] = checkOut;
                TempData["maxPeople"] = maxPeople;
            

                var roomType = _roomTypeService.GetRoomByMaxPeople(maxPeople);
                
                int roomTypeID = roomType.ID;
                var roomModel = _roomService.GetListRoomAvailable(roomTypeID, checkIn, checkOut);
                var roomViewModel = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(roomModel);
                return View(roomViewModel);
            }
            else
                return null;
        }
       
    }
}