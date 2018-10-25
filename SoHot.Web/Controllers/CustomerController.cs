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
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertCustomer(FormCollection Fields)
        {
            var customer = new Customer
            {
                Name = Convert.ToString(Fields["name"]),
                Email = Convert.ToString(Fields["email"]),
                Phone = Convert.ToString(Fields["phone"]),
                PassportNumber = Convert.ToString(Fields["passport"]),
                Nationality = Convert.ToString(Fields["nationality"]),
                Address = Convert.ToString(Fields["address"]),
                CreatedBy = null,
                DateOfBirth = Convert.ToDateTime(Fields["birth"]),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacebookID = null,
                Status = true
            };
            var customerModel = _customerService.Add(customer);
            var roomViewModel = Mapper.Map<Customer, CustomerViewModel>(customerModel);
            return View(roomViewModel);
        }
    }
}