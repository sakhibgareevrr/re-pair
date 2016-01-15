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
    public class BusinessService
    {

        private UserAddressRepository _userAddressRepo;

        private OrderRepository _orderRepo;

        private BusinessRepository _businessRepo;

        private ApplicationUserManager _userManager;

        public BusinessService(UserAddressRepository userAddressRepo, OrderRepository orderRepo, BusinessRepository businessRepo, ApplicationUserManager userMan)
        {
            _userAddressRepo = userAddressRepo;
            _orderRepo = orderRepo;
            _businessRepo = businessRepo;
            _userManager = userMan;
        }

        public IList<BusinessUserDTO> List()
        {
            return (from b in _businessRepo.ListAll()
                    select Map(b)).ToList();
        }

        public BusinessUserDTO FindByBusinessUserName(string username)
        {
            return Map(_businessRepo.FindByBusinessUserName(username));
        }

        public void Register(RegisterBusinessBindingModel model)
        {
            var business = new BusinessUser
            {
                UserName = model.Email,
                Email = model.Email,
                CompanyName = model.CompanyName,
                ServiceCategory = model.ServiceCategory,
                Description = model.Description,
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

            _userManager.Create(business, model.Password);
        }


        private BusinessUserDTO Map(BusinessUser dbCustomer)
        {

            return dbCustomer != null ? new BusinessUserDTO()
            {
                Id = dbCustomer.Id,
                UserName = dbCustomer.UserName,
                CompanyName = dbCustomer.CompanyName,
                ServiceCategory = dbCustomer.ServiceCategory,
                Description = dbCustomer.Description,
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