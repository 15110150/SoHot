using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using SoHot_Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot.Service
{
    public interface IRoomTypeService
    {
        RoomType Add(RoomType roomType);

        void Update(RoomType roomType);

        RoomType Delete(int id);

        IEnumerable<RoomType> GetAll();

        IEnumerable<RoomType> GetAll(string keyword);

        RoomType GetById(int id);

        void Save();
        RoomType GetRoomByMaxPeople(int people);
     


    }

    public class RoomTypeService : IRoomTypeService
    {
        private IRoomTypeRepository _roomTypeRepository;
        private IRoomRepository _roomRepository;
        private IUnitOfWork _unitOfWork;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork, IRoomRepository roomRepository)
        {
            this._roomTypeRepository = roomTypeRepository;
            this._unitOfWork = unitOfWork;
            this._roomRepository = roomRepository;
        }

        public RoomType Add(RoomType roomType)
        {
            return _roomTypeRepository.Add(roomType);
        }

        public RoomType Delete(int id)
        {
            return _roomTypeRepository.Delete(id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _roomTypeRepository.GetAll();
        }
        public IEnumerable<RoomType> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _roomTypeRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _roomTypeRepository.GetAll();

        }
        public RoomType GetById(int id)
        {
            return _roomTypeRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(RoomType roomType)
        {
            _roomTypeRepository.Update(roomType);
        }
       public RoomType GetRoomByMaxPeople(int people)
        {
            return _roomTypeRepository.GetSingleByCondition(x => x.MaxPeople == people);
           

        }
     
    }
}
