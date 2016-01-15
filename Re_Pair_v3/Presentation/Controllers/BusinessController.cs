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
    [RoutePrefix("api/businesses")]
    public class BusinessesController : ApiController
    {
        private BusinessService _businessService;

        public BusinessesController(BusinessService businessService)
        {
            _businessService = businessService;
        }

        
        [HttpGet]
        public IList<BusinessUserDTO> Get()
        {
            return _businessService.List();
        }

        [Route("search/{username}")]
        [HttpGet]
        public BusinessUserDTO GetByUserName(string username)
        {
            return _businessService.FindByBusinessUserName(username);
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register(RegisterBusinessBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _businessService.Register(model);
            return Ok();
        }

    }
}
