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
    public interface IReservationService
    {
        Reservation Create(Reservation reservation, List<DetailReservation> detailReservations);

        void Update(Reservation Reservation);

        Reservation Delete(int id);

        IEnumerable<Reservation> GetAll();

        Reservation GetById(int id);

        void Save();
    }

    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepository;
        private IDetailReservationRepository _detailReservationRepository;
        private IUnitOfWork _unitOfWork;

        public ReservationService(IReservationRepository reservationRepository, IDetailReservationRepository detailReservationRepository, IUnitOfWork unitOfWork)
        {
            this._reservationRepository = reservationRepository;
            this._detailReservationRepository = detailReservationRepository;
            this._unitOfWork = unitOfWork;
        }

        public Reservation Create(Reservation reservation, List<DetailReservation> detailReservations)
        {
            try
            {
                _reservationRepository.Add(reservation);
                _unitOfWork.Commit();

                foreach (var detailReservation in detailReservations)
                {
                    detailReservation.ReservationID = reservation.ID;
                    _detailReservationRepository.Add(detailReservation);
                }
                return reservation;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Reservation Delete(int id)
        {
            return _reservationRepository.Delete(id);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

       
        public Reservation GetById(int id)
        {
            return _reservationRepository.GetSingleById(id);
        }

        public void Save()
        {
           
            _unitOfWork.Commit();
        }

        public void Update(Reservation Reservation)
        {
            _reservationRepository.Update(Reservation);
           
        }

    }
}
    //public interface IReservationService
    //{
    //    Reservation Create(ref Reservation reservation);

    //    void UpdateStatus(int reservationId);

    //    void Save();
    //}

    //public class ReservationService : IReservationService
    //{
    //    private IReservationRepository _reservationRepository;
    //    private IUnitOfWork _unitOfWork;

    //    public ReservationService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
    //    {
    //        this._reservationRepository = reservationRepository;
    //        this._unitOfWork = unitOfWork;
    //    }

    //    public Reservation Create(ref Reservation order)
    //    {
    //        try
    //        {
    //            _reservationRepository.Add(order);
    //            _unitOfWork.Commit();
    //            return order;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }

    //    public void UpdateStatus(int orderId)
    //    {
    //        var order = _reservationRepository.GetSingleById(orderId);
    //        order.Status = true;
    //        _reservationRepository.Update(order);
    //    }

    //    public void Save()
    //    {
    //        _unitOfWork.Commit();
    //    }
    //}

