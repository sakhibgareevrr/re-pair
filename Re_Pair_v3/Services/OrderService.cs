using Re_Pair_v3.Domain.Models;
using Re_Pair_v3.Infrastructure.Repository;
using Re_Pair_v3.Models;
using Re_Pair_v3.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Services
{
    public class OrderService
    {
        private OrderRepository _repo;
        private BusinessRepository _businessRepo;
        private CustomerRepository _customerRepo;

        public OrderService(OrderRepository repo, BusinessRepository businessRepo, CustomerRepository customerRepo)
        {
            _repo = repo;
            _businessRepo = businessRepo;
            _customerRepo = customerRepo;
        }

        public OrderDTO FindByIdBusiness(int id, string businessusername)
        {
            return Map(_repo.FindByIdBusiness(id, businessusername));
        }

        public OrderDTO FindByIdCustomer(int id, string customerusername)
        {
            return Map(_repo.FindByIdCustomer(id, customerusername));
        }

        public IList<OrderDTO> FindByCustomerId(string customerid)
        {
            return (from o in _repo.FindByCustomerId(customerid)
                    select Map(o)).ToList();
        }

        public IList<OrderDTO> FindByCustomerUserName(string customerusername)
        {
            return (from o in _repo.FindByCustomerId(customerusername)
                    select Map(o)).ToList();
        }

        public IList<OrderDTO> FindByCustomerEmail(string customeremail)
        {
            return (from o in _repo.FindByCustomerId(customeremail)
                    select Map(o)).ToList();
        }

        public IList<OrderDTO> FindByBusinessId(string businessid)
        {
            return (from o in _repo.FindByCustomerId(businessid)
                    select Map(o)).ToList();
        }

        public IList<OrderDTO> FindByBusinessUserName(string businessusername)
        {
            return (from o in _repo.FindByBusinessId(businessusername)
                    select Map(o)).ToList();
        }

        public IList<OrderDTO> FindByBusinessEmail(string businessemail)
        {
            return (from o in _repo.FindByBusinessId(businessemail)
                    select Map(o)).ToList();
        }

        public OrderDTO FindById(int id, string username)
        {
            return Map(_repo.FindById(id, username));
        }

        public IList<OrderDTO> List(string username)
        {
            return (from a in _repo.FindByUserName(username)
                    select Map(a)).ToList();
        }

        public void CreateOrder(OrderBindingModel model)
        {
            var order = new Order
            {
                Business = _businessRepo.FindByBusinessUserName(model.BusinessUserName),
                Customer = _customerRepo.FindByCustomerUserName(model.CustomerUserName),
                ServiceName = model.ServiceName,
                OrderDate = DateTime.Parse(model.OrderDate),
                CompletionDate = DateTime.Parse(model.CompletionDate),
                Price = model.Price,
                ServiceQuality = 0,
                IsApproved = false,
                IsCompleted = false
            };
            _repo.Add(order);
            _repo.SaveChanges();
        }

        public void UpdateOrder(int id, OrderBindingModel model, string username)
        {
            Order order = _repo.FindById(id, username);
            if (order != null)
            {
               
                order.Customer = _customerRepo.FindByCustomerUserName(model.CustomerUserName);
                order.ServiceName = model.ServiceName;
                order.OrderDate = DateTime.Parse(model.OrderDate);
                order.CompletionDate = DateTime.Parse(model.CompletionDate);
                order.Price = model.Price;
                order.ServiceQuality = model.ServiceQuality;
                order.IsApproved = model.IsApproved;
                order.IsCompleted = model.IsCompleted;
            };
       
            _repo.SaveChanges();
        }


        private OrderDTO Map(Order dbOrder)
        {
            return dbOrder != null ? new OrderDTO()
            {
                Id = dbOrder.Id,
                Business = new BusinessUserDTO()
                {
                    Id = dbOrder.Business.Id,
                    UserName = dbOrder.Business.UserName,
                    CompanyName = dbOrder.Business.CompanyName,
                    ServiceCategory = dbOrder.Business.ServiceCategory,
                    Description = dbOrder.Business.Description
                },
                Customer = new CustomerUserDTO()
                {
                    Id = dbOrder.Customer.Id,
                    UserName = dbOrder.Customer.UserName,
                },
                ServiceName = dbOrder.ServiceName,
                OrderDate = dbOrder.OrderDate,
                CompletionDate = dbOrder.CompletionDate,
                Price = dbOrder.Price,
                ServiceQuality = dbOrder.ServiceQuality,
                IsApproved = dbOrder.IsApproved,
                IsCompleted = dbOrder.IsCompleted
            } : null;
        }
    }
}