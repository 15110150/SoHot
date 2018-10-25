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
    public class ReservationController : Controller
    {
       
        // GET: Reservation
        IRoomService _roomService;
        ICustomerService _customerService;
        IReservationService _reservationService;
        public int _id;
        public ReservationController(IRoomService roomService, ICustomerService customerService, IReservationService reservationService)
        {
            _roomService = roomService;
            _customerService = customerService;
            _reservationService = reservationService;
        }
        [ChildActionOnly]
        public ActionResult RoomBooking(int id)
        {
            ViewBag.checkIn = Convert.ToString(TempData["checkIn"]);
            TempData["checkIn"] = ViewBag.checkIn;
            ViewBag.checkOut = Convert.ToString(TempData["checkOut"]);
            TempData["checkOut"] = ViewBag.checkOut;
            ViewBag.maxPeople = Convert.ToString(TempData["maxPeople"]);
            TempData["maxPeople"] = ViewBag.maxPeople;
            DateTime checkIn = Convert.ToDateTime(TempData["checkIn"]);
            TempData["checkIn"] = checkIn;
            DateTime checkOut = Convert.ToDateTime(TempData["checkOut"]);
            TempData["checkOut"] = checkOut;
            TempData["Id"] = id;
            double stay = checkOut.Subtract(checkIn).TotalDays;

            ViewBag.stay = stay.ToString();

            var roomModel = _roomService.GetRoomByID(id);
            var roomViewModel = Mapper.Map<Room, RoomViewModel>(roomModel);


            decimal price = roomModel.Price * decimal.Parse(stay.ToString());
            ViewBag.totalPrice = price.ToString();
            TempData["price"] = price;


            return PartialView(roomViewModel);
        }
        public ActionResult Index(int id)
        {
            _id = id;
            ViewBag.RoomID = id;
            var roomModel = _roomService.GetRoomByID(id);
            var roomViewModel = Mapper.Map<Room, RoomViewModel>(roomModel);
            return View(roomViewModel);
        
        }
        //public ActionResult CheckInformation(FormCollection Fields)
        //{
        //    var customer = new Customer
        //    {
        //        Name = Convert.ToString(Fields["name"]),
        //        Email = Convert.ToString(Fields["email"]),
        //        Phone = Convert.ToString(Fields["phone"]),
        //        PassportNumber = Convert.ToString(Fields["passport"]),
        //        Nationality = Convert.ToString(Fields["nationality"]),
        //        Address = Convert.ToString(Fields["address"]),
        //        CreatedBy = null,
        //        DateOfBirth = Convert.ToDateTime(Fields["birth"]),
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = DateTime.Now,
        //        FacebookID = null,
        //        Status = true
        //    };
        //    var customerModel = _customerService.Add(customer);
        //    _customerService.Save();
        //    var customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customerModel);


        //    var reservation = new Reservation
        //    {
        //        Customer = customer,
        //        CheckInDateTime = Convert.ToDateTime(TempData["checkIn"]),
        //        CheckOutDateTime = Convert.ToDateTime(TempData["checkOut"]),

        //        Price = Convert.ToDecimal(TempData["price"]),
        //        IsPaid = false,
        //        Quantity = 1,
        //        Total = Convert.ToDecimal(TempData["price"]),
        //        CustomerID = customer.ID,
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = DateTime.Now,
        //        Status = true

        //    };
        //    var reservationViewModel = _reservationService.Add(reservation);
        //    _reservationService.Save();

        //    ViewBag.RoomID = TempData["Id"];

        //    return View(customerViewModel);
        //}
        public ActionResult Booking(FormCollection Fields)
        {

            return View();
        }
    }
}