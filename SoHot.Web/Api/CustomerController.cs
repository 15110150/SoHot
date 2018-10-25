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

    [RoutePrefix("api/customer")]
    public class CustomerController : ApiControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(IErrorService errorService, ICustomerService customerService)
            : base(errorService)
        {
            this._customerService = customerService;
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _customerService.GetById(id);

                var responseData = Mapper.Map<Customer, CustomerViewModel>(model);

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
                var model = _customerService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        //[Route("create")]
        //[HttpPost]
        //[AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, CustomerViewModel customerVm)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var newCustomer = new Customer();
        //            newCustomer.UpdateCustomer(customerVm);
        //            newCustomer.CreatedDate = DateTime.Now;
        //            if (newCustomer.DateOfBirth.Date.Equals(DateTime.MinValue)){
        //                newCustomer.DateOfBirth = DateTime.Now;
        //            }
        //            _customerService.Add(newCustomer);
        //            _customerService.Save();

        //            var responseData = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //        }

        //        return response;
        //    });
        //}

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, CustomerViewModel customerVm)
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
                    var newCustomer = new Customer();
                    newCustomer.UpdateCustomer(customerVm);
                    newCustomer.CreatedDate = DateTime.Now;
                    if (newCustomer.DateOfBirth.Date.Equals(DateTime.MinValue))
                    {
                        newCustomer.DateOfBirth = DateTime.Now;
                    }
                    _customerService.Add(newCustomer);
                    _customerService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData.ID);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CustomerViewModel customerVm)
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
                    var dbcustomer = _customerService.GetById(customerVm.ID);

                    dbcustomer.UpdateCustomer(customerVm);
                    dbcustomer.UpdatedDate = DateTime.Now;

                    _customerService.Update(dbcustomer);
                    _customerService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(dbcustomer);
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
                    var oldCustomer = _customerService.Delete(id);
                    _customerService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(oldCustomer);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("getbyphone/{phone}")]
        [HttpGet]
        public HttpResponseMessage GetByPhone(HttpRequestMessage request, string phone)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _customerService.GetByPhoneNumber(phone);

                var responseData = Mapper.Map<Customer, CustomerViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        //[Route("getbypassport/{passport}")]
        //[HttpGet]
        //public HttpResponseMessage GetByPassport(HttpRequestMessage request, string passport)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _customerService.GetByPassportNumber(passport);

        //        var responseData = Mapper.Map<Customer, CustomerViewModel>(model);

        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);

        //        return response;
        //    });
        //} 

        [Route("getbypassport/{passport}")]
        [HttpGet]
        public HttpResponseMessage GetByPassport(HttpRequestMessage request, string passport)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _customerService.GetByPassportNumber(passport);

                var responseData = Mapper.Map<Customer, CustomerViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData.ID);

                return response;
            });
        }


    }
}
