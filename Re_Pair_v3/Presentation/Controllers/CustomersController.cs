using Re_Pair_v3.Models;
using Re_Pair_v3.Presentation.Models;
using Re_Pair_v3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Re_Pair_v3.Presentation.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        
        [HttpGet]
        public CustomerUserDTO Get()
        {
            return _customerService.List(User.Identity.Name);
        }

        //[Route("api/businesscustomers/")]
        //[HttpGet]
        //public IList<CustomerUserDTO> GetByBusinessUserName()
        //{
        //    return _customerService.FindByBusinessUserName(User.Identity.Name);
        //}

        [Route("search/{username}")]
        [HttpGet]
        public CustomerUserDTO GetByUserName(string username)
        {
            return _customerService.FindByCustomerUserName(username);
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register(RegisterCustomerBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _customerService.Register(model);
            return Ok();
        }
    }
}
