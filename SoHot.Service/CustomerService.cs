using SoHot.Common;
using SoHot.Model.Models;
using SoHot_Data.Insfrastructure;
using SoHot_Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SoHot.Service
{
    public interface ICustomerService
    {
        Customer Add(Customer Customer);

        void Update(Customer Customer);

        Customer Delete(int id);

        IEnumerable<Customer> GetAll();

        IEnumerable<Customer> GetAll(string keyword);

        Customer GetById(int id);

        void Save();
        Customer GetByPhoneNumber(string keyword);
        Customer GetByPassportNumber(string keyword);
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Customer Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public Customer Delete(int id)
        {
            return _customerRepository.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
        public IEnumerable<Customer> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _customerRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _customerRepository.GetAll();

        }
        public Customer GetById(int id)
        {
            return _customerRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
        public Customer GetByPhoneNumber(string keyword)
        {
            return _customerRepository.GetSingleByCondition(x => x.Phone == keyword);

        }
        public Customer GetByPassportNumber(string keyword)
        {
            return _customerRepository.GetSingleByCondition(x => x.PassportNumber == keyword);

        }
    }
}
