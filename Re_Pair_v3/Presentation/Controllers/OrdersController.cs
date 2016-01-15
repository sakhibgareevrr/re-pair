using Re_Pair_v3.Presentation.Models;
using Re_Pair_v3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Re_Pair_v3.Presentation.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {

        private OrderService _ordersService;

        public OrdersController(OrderService ordersService)
        {
            _ordersService = ordersService;
        }

        
        [HttpGet]
        public IList<OrderDTO> Get()
        {
            return _ordersService.List(User.Identity.Name);
        }

        [HttpPost]
        public IHttpActionResult Post(OrderBindingModel model)
        {
            model.CustomerUserName = User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ordersService.CreateOrder(model);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Post(int id, OrderBindingModel model)
        {
            model.CustomerUserName = User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ordersService.UpdateOrder(id, model, User.Identity.Name);
            return Ok();
        }


        [Route("search/{username}")]
        [HttpGet]
        public IList<OrderDTO> GetByUserName(string username)
        {
            return _ordersService.List(username);
        }



        public IHttpActionResult Get(int id)
        {
            var order = _ordersService.FindById(id, User.Identity.Name);

            if (order != null)
            {
                return Ok(order);
            }
            return BadRequest();
        }


    }
}
