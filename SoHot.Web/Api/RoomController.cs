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
    [RoutePrefix("api/room")]
    public class RoomController : ApiControllerBase
    {
        private IRoomService _roomService;
        private IRoomTypeService _roomTypeService;

        public RoomController(IErrorService errorService, IRoomService roomService, IRoomTypeService roomTypeService)
            : base(errorService)
        {
            this._roomService = roomService;
            this._roomTypeService = roomTypeService;
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roomService.GetById(id);

                var responseData = Mapper.Map<Room, RoomViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
        [Route("getbyroomtype/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetRoomByRoomType(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roomService.GetListRoomByCategory(id);

                var responseData = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _roomService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(query);

                var paginationSet = new PaginationSet<RoomViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("getavailble")]
        public HttpResponseMessage GetAvailable(HttpRequestMessage request, DateTime checkIn, DateTime checkOut, int maxPeople)
        {
            return CreateHttpResponse(request, () =>
            {
                //var roomType = _roomTypeService.GetRoomByMaxPeople(maxPeople);
                int roomTypeID = maxPeople;

                var model = _roomService.GetListRoomAvailable(roomTypeID, checkIn, checkOut);
                var responseData = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getnumber")]
        public HttpResponseMessage GetNumber(HttpRequestMessage request, DateTime checkIn, DateTime checkOut, int maxPeople)
        {
            return CreateHttpResponse(request, () =>
            {
                var roomType = _roomTypeService.GetRoomByMaxPeople(maxPeople);
                int roomTypeID = roomType.ID;

                var model = _roomService.NummberOfRoomIsAvailable(roomTypeID, checkIn, checkOut);
                
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }


        [Route("getPrice")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage GetPrice(HttpRequestMessage request, List<int> ids)
        {
            return CreateHttpResponse(request, () =>
            {
               decimal total = 0;
               foreach(int id in ids)
                {
                    total += _roomService.GetById(id).Price;
                }

               

                var response = request.CreateResponse(HttpStatusCode.OK, total);
                return response;
            });
        }





        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roomService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Room>, IEnumerable<Room>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, RoomViewModel roomVm)
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
                    var newRoom = new Room();
                    newRoom.UpdateRoom(roomVm);
                    newRoom.CreatedDate = DateTime.Now;
                    _roomService.Add(newRoom);
                    _roomService.Save();

                    var responseData = Mapper.Map<Room, RoomViewModel>(newRoom);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, RoomViewModel roomVm)
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
                    var dbRoom= _roomService.GetById(roomVm.ID);

                    dbRoom.UpdateRoom(roomVm);
                    dbRoom.UpdatedDate = DateTime.Now;

                    _roomService.Update(dbRoom);
                    _roomService.Save();

                    var responseData = Mapper.Map<Room, RoomViewModel>(dbRoom);
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
                    var oldRoom = _roomService.Delete(id);
                    _roomService.Save();

                    var responseData = Mapper.Map<Room, RoomViewModel>(oldRoom);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
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
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);
                    foreach (var item in listProductCategory)
                    {
                        _roomService.Delete(item);
                    }

                    _roomService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }

                return response;
            });
        }
        [Route("getbyroomavailable/{id:int}/{checkIn:DateTime}/{checkOut:DateTime}")]
        [HttpGet]
        public HttpResponseMessage GetRoomAvailable(HttpRequestMessage request, int roomTypeId, DateTime checkIn, DateTime checkOut)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roomService.GetListRoomAvailable(roomTypeId, checkIn, checkOut);

                var responseData = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}
