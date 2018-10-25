using AutoMapper;
using SoHot.Model.Models;
using SoHot.Service;
using SoHot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoHot.Web.Controllers
{
    public class HomeController : Controller
    {
        IRoomTypeService _roomTypeService;
        IRoomService _roomService;
        public HomeController(IRoomTypeService roomTypeService, IRoomService roomService)
        {
            _roomTypeService = roomTypeService;
            _roomService = roomService;
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult RoomRecommend()
        {
            var model = _roomService.GetHotRoom(5);
            var listRoomViewModel = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(model);
            return PartialView(listRoomViewModel);
        }
        [ChildActionOnly]
        public ActionResult SearchRoom()
        {
            return PartialView();
        }
        public ActionResult Index()
        {
            var model = _roomTypeService.GetAll();
            var listRoomtypeViewModel = Mapper.Map<IEnumerable<RoomType>, IEnumerable<RoomTypeViewModel>>(model);
            return View(listRoomtypeViewModel);
        }
    }
}