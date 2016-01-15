using CoderCamps.Infrastructure.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Re_Pair_v3.Domain.Models;
using Re_Pair_v3.Infrastructure.Repository;
using Re_Pair_v3.Models;
using Re_Pair_v3.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Services
{

    public class CustomerService
    {
        private UserAddressRepository _userAddressRepo;

        private OrderRepository _orderRepo;

        private CustomerRepository _customerRepo;

        private ApplicationUserManager _userManager;

        //public CustomerService(OrderRepository orderRepo, ApplicationUserManager userMan)
        public CustomerService(UserAddressRepository userAddressRepo, OrderRepository orderRepo, CustomerRepository customerRepo, ApplicationUserManager userMan)
        {
            _userAddressRepo = userAddressRepo;
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
            _userManager = userMan;
        }

        public CustomerUserDTO List(string username)
        {
            return Map(_customerRepo.FindByCustomerUserName(username));
        }

        //public IList<CustomerUserDTO> FindByBusinessUserName(string username)
        //{
        //    return (from c in _customerRepo.FindByBusinessUserName(username)
        //            select Map(c)).ToList();
        //}

        public CustomerUserDTO FindByCustomerUserName(string username)
        {
            return Map(_customerRepo.FindByCustomerUserName(username));
        }

        public void Register(RegisterCustomerBindingModel model)
        {
            var customer = new CustomerUser
            {
                UserName = model.Email,
                Email = model.Email,
                Orders = new List<Order>(),
                UserAddresses = new List<UserAddress>() { new UserAddress() {
                                     FirstName = model.PrimaryAddress.FirstName,
                                     LastName = model.PrimaryAddress.LastName,
                                     Phone = model.PrimaryAddress.Phone,
                                     AddressLine1 = model.PrimaryAddress.AddressLine1,
                                     AddressLine2 = model.PrimaryAddress.AddressLine2,
                                     City = model.PrimaryAddress.City,
                                     State = model.PrimaryAddress.State,
                                     Zipcode = model.PrimaryAddress.Zipcode
                                 }
                }
            };
            _userManager.Create(customer, model.Password);
        }

        private CustomerUserDTO Map(CustomerUser dbCustomer)
        {

            return dbCustomer != null ? new CustomerUserDTO()
            {
                Id = dbCustomer.Id,
                UserName = dbCustomer.UserName,
                Email = dbCustomer.Email,
                Orders = (from order in dbCustomer.Orders
                          select new OrderDTO()
                          {
                              Id = order.Id,
                              ServiceName = order.ServiceName,
                              OrderDate = order.OrderDate,
                              CompletionDate = order.CompletionDate,
                              Price = order.Price,
                              ServiceQuality = order.ServiceQuality,
                              IsApproved = order.IsApproved,
                              IsCompleted = order.IsCompleted
                          }).ToList(),
                UserAddresses = (from useraddress in dbCustomer.UserAddresses
                                 select new UserAddressDTO()
                                 {
                                     FirstName = useraddress.FirstName,
                                     LastName = useraddress.LastName,
                                     Phone = useraddress.Phone,
                                     AddressLine1 = useraddress.AddressLine1,
                                     AddressLine2 = useraddress.AddressLine2,
                                     City = useraddress.City,
                                     State = useraddress.State,
                                     Zipcode = useraddress.Zipcode

                                 }).ToList()
            } : null;
        }
    }
}