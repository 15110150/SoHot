using SoHot.Common;
using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using SoHot_Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoHot.Service
{
    public interface IRoomService
    {
        Room Add(Room Room);

        void Update(Room Room);

        Room Delete(int id);
        Room GetRoomByID(int id);

        IEnumerable<Room> GetAll();

        IEnumerable<Room> GetAll(string keyword);

        IEnumerable<Room> GetLastest(int top);

        IEnumerable<Room> GetHotRoom(int top);

        IEnumerable<Room> GetListRoomByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<Room> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<Room> GetReatedRooms(int id, int top);

        IEnumerable<string> GetListRoomByName(string name);

        Room GetById(int id);

        void Save();
        IEnumerable<Room> GetListRoomByCategory(int roomTypeId);
        IEnumerable<Tag> GetListTagByRoomId(int id);

        Tag GetTag(string tagId);

        void IncreaseView(int id);

        IEnumerable<Room> GetListRoomByTag(string tagId, int page, int pageSize, out int totalRow);
        IEnumerable<Room> GetListRoomAvailable(int roomTypeID, DateTime checkIn, DateTime checkOut);
        int NummberOfRoomIsAvailable(int roomTypeID, DateTime checkIn, DateTime checkOut);
    }

    public class RoomService : IRoomService
    {
        private IRoomRepository _roomRepository;
        private ITagRepository _tagRepository;
        private IRoomTagRepository _roomTagRepository;

        private IUnitOfWork _unitOfWork;

        public RoomService(IRoomRepository roomRepository, IRoomTagRepository roomTagRepository,
            ITagRepository _tagRepository, IUnitOfWork unitOfWork)
        {
            this._roomRepository = roomRepository;
            this._roomTagRepository = roomTagRepository;
            this._tagRepository = _tagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Room Add(Room Room)
        {
            var room = _roomRepository.Add(Room);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(Room.Tags))
            {
                string[] tags = Room.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if(_tagRepository.Count(x=>x.ID==tagId)==0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.RoomTag;
                        _tagRepository.Add(tag);
                    }
                    RoomTag roomTag = new RoomTag();
                    roomTag.RoomID = Room.ID;
                    roomTag.TagID = tagId;
                    _roomTagRepository.Add(roomTag);
                }
            }
            return room;
        }

        public Room Delete(int id)
        {
            return _roomRepository.Delete(id);
        }
        public Room GetRoomByID(int id)
        {
            return _roomRepository.GetSingleByCondition(x => x.ID==id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public IEnumerable<Room> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _roomRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _roomRepository.GetAll();
        }

        public Room GetById(int id)
        {
            return _roomRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Room Room)
        {
            _roomRepository.Update(Room);
            if (!string.IsNullOrEmpty(Room.Tags))
            {
                string[] tags = Room.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.RoomTag;
                        _tagRepository.Add(tag);
                    }
                    _roomRepository.DeleteMulti(x => x.ID == Room.ID);
                    RoomTag roomTag = new RoomTag();
                    roomTag.RoomID = Room.ID;
                    roomTag.TagID = tagId;
                    _roomTagRepository.Add(roomTag);
                }
            }
        }

        public IEnumerable<Room> GetLastest(int top)
        {
            return _roomRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Room> GetHotRoom(int top)
        {
            return _roomRepository.GetMulti(x => x.Status && x.HotFlag == true).OrderByDescending(x => x.CreatedDate).Take(top);
        }
        public IEnumerable<Room> GetListRoomByCategory(int roomTypeId)
        {
            var query = _roomRepository.GetMulti(x => x.Status && x.RoomTypeID == roomTypeId);
            return query;
        }

            public IEnumerable<Room> GetListRoomByCategoryIdPaging(int roomTypeId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _roomRepository.GetMulti(x => x.Status && x.RoomTypeID == roomTypeId);

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<string> GetListRoomByName(string name)
        {
            return _roomRepository.GetMulti(x => x.Status && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Room> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _roomRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Room> GetReatedRooms(int id, int top)
        {
            var room = _roomRepository.GetSingleById(id);
            return _roomRepository.GetMulti(x => x.Status && x.ID != id && x.RoomTypeID == room.RoomTypeID).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Tag> GetListTagByRoomId(int id)
        {
            return _roomTagRepository.GetMulti(x => x.RoomID == id, new string[] { "Tag" }).Select(y => y.Tag);
        }

        public void IncreaseView(int id)
        {
            var room = _roomRepository.GetSingleById(id);
            if (room.ViewCount.HasValue)
                room.ViewCount += 1;
            else
                room.ViewCount = 1;
        }

        public Tag GetTag(string tagId)
        {
            return _tagRepository.GetSingleByCondition(x => x.ID == tagId);
        }

        public IEnumerable<Room> GetListRoomByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var model = _roomRepository.GetListRoomByTag(tagId, page, pageSize, out totalRow);
            return model;
        }
        public IEnumerable<Room> GetListRoomAvailable(int roomTypeID, DateTime checkIn, DateTime checkOut)
        {
            var model = _roomRepository.GetListRoomAvailable(roomTypeID, checkIn, checkOut);
            return model;
        }
        public int NummberOfRoomIsAvailable(int roomTypeID, DateTime checkIn, DateTime checkOut)
        {
            return _roomRepository.NummberOfRoomIsAvailable(roomTypeID, checkIn, checkOut);
        }
    }
}