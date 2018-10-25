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
    [RoutePrefix("api/roomtype")]
    public class RoomTypeController : ApiControllerBase
    {
        private IRoomTypeService _roomTypeService;
        private IRoomService _roomService;

        public RoomTypeController(IErrorService errorService, IRoomTypeService roomTypeService, IRoomService roomService)
            : base(errorService)
        {
            this._roomTypeService = roomTypeService;
            this._roomService = roomService;
        }
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roomTypeService.GetAll();

                var responseData = Mapper.Map<IEnumerable<RoomType>, IEnumerable<RoomTypeViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roomTypeService.GetById(id);

                var responseData = Mapper.Map<RoomType, RoomTypeViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

      
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _roomTypeService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<RoomType>, IEnumerable<RoomTypeViewModel>>(query);

                var paginationSet = new PaginationSet<RoomTypeViewModel>()
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
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, RoomTypeViewModel roomTypeVm)
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
                    var newRoomType = new RoomType();
                    newRoomType.UpdateRoomType(roomTypeVm);
                    newRoomType.CreatedDate = DateTime.Now;
                    _roomTypeService.Add(newRoomType);
                    _roomTypeService.Save();

                    var responseData = Mapper.Map<RoomType, RoomTypeViewModel>(newRoomType);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, RoomTypeViewModel roomTypeVm)
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
                    var dbRoomType = _roomTypeService.GetById(roomTypeVm.ID);

                    dbRoomType.UpdateRoomType(roomTypeVm);
                    dbRoomType.UpdatedDate = DateTime.Now;

                    _roomTypeService.Update(dbRoomType);
                    _roomTypeService.Save();

                    var responseData = Mapper.Map<RoomType, RoomTypeViewModel>(dbRoomType);
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
                    var oldRoomType = _roomTypeService.Delete(id);
                    _roomTypeService.Save();

                    var responseData = Mapper.Map<RoomType, RoomTypeViewModel>(oldRoomType);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("getRoomTypeWithRoomQuanity")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetRoomTypeWithRoomQuannity(HttpRequestMessage request, DateTime checkIn, DateTime checkOut)
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
                    //Chỗ này sẽ gọi service trả về list các RoomType có chứa các phòng còn trống tại thời điểm cần tìm
                    var roomTypes = _roomTypeService.GetAll();
                    
                    var responseData = Mapper.Map<IEnumerable<RoomType>, IEnumerable<RoomTypeViewModel>>(roomTypes);
                    foreach(RoomTypeViewModel roomType in responseData)
                    {
                        roomType.Rooms = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>
                        (_roomService.GetListRoomAvailable(roomType.ID, checkIn, checkOut));
                    }
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                    return response;
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
                        _roomTypeService.Delete(item);
                    }

                    _roomTypeService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }

                return response;
            });
        }
    }
}