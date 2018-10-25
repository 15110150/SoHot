using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoHot_Data.Repositories;

namespace SoHot.Service
{
    public interface IBillService
    {
        Bill Create(ref Bill bill);

        void UpdateStatus(int billId);

        void Save();
    }

    public class BillService : IBillService
    {
        private IBillRepository _billRepository;
        private IUnitOfWork _unitOfWork;

        public BillService(IBillRepository billRepository, IUnitOfWork unitOfWork)
        {
            this._billRepository = billRepository;
            this._unitOfWork = unitOfWork;
        }

        public Bill Create(ref Bill order)
        {
            try
            {
                _billRepository.Add(order);
                _unitOfWork.Commit();
                return order;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateStatus(int orderId)
        {
            var order = _billRepository.GetSingleById(orderId);
            order.Status = true;
            _billRepository.Update(order);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
