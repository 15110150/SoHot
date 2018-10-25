using AutoMapper;
using SoHot.Model.Models;
using SoHot.Service;
using SoHot.Web.Infrastructure.Core;
using SoHot.Web.Infrastructure.Extension;
using SoHot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace SoHot.Web.Api
{
    [RoutePrefix("api/reservation")]
    public class ReservationController : ApiControllerBase
    {
        private IReservationService _reservationService;

        public ReservationController(IErrorService errorService, IReservationService reservationService)
            : base(errorService)
        {
            this._reservationService = reservationService;
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _reservationService.GetById(id);

                var responseData = Mapper.Map<Reservation, ReservationViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _reservationService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ReservationAndRooms reservationAndRooms)
        {
            return CreateHttpResponse(request, () =>
            {
                ReservationViewModel reservationVm = reservationAndRooms.ReservationViewModel;
                List<Room> rooms = reservationAndRooms.Rooms;
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newReservation = new Reservation();
                    newReservation.UpdateReservation(reservationVm);
                    newReservation.CreatedDate = DateTime.Now;


                    List<DetailReservation> detailReservations = new List<DetailReservation>();
                    foreach(var item in rooms)
                    {
                        var detail = new DetailReservation();
                        detail.RoomID = item.ID;
                        detailReservations.Add(detail);
                    }
                    _reservationService.Create(newReservation, detailReservations);
                    _reservationService.Save();

                    var responseData = Mapper.Map<Reservation, ReservationViewModel>(newReservation);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }


        [Route("create2")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create2(HttpRequestMessage request, ReservationAndRooms2 reservationAndRooms2)
        {
            return CreateHttpResponse(request, () =>
            {
                ReservationViewModel reservationVm = reservationAndRooms2.ReservationViewModel;
                List<int> rooms = reservationAndRooms2.Rooms;
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newReservation = new Reservation();
                    newReservation.UpdateReservation(reservationVm);
                    newReservation.CreatedDate = DateTime.Now;


                    List<DetailReservation> detailReservations = new List<DetailReservation>();
                    foreach (var item in rooms)
                    {
                        var detail = new DetailReservation();
                        detail.RoomID = item;
                        detailReservations.Add(detail);
                    }
                    _reservationService.Create(newReservation, detailReservations);
                    _reservationService.Save();

                    var responseData = Mapper.Map<Reservation, ReservationViewModel>(newReservation);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ReservationViewModel reservationVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbreservation = _reservationService.GetById(reservationVm.ID);

                    dbreservation.UpdateReservation(reservationVm);
                    dbreservation.UpdatedDate = DateTime.Now;

                    _reservationService.Update(dbreservation);
                    _reservationService.Save();

                    var responseData = Mapper.Map<Reservation, ReservationViewModel>(dbreservation);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldReservation = _reservationService.Delete(id);
                    _reservationService.Save();

                    var responseData = Mapper.Map<Reservation, ReservationViewModel>(oldReservation);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

    }
}
