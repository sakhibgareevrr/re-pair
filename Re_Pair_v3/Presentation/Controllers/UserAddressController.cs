using Re_Pair_v3.Models;
using Re_Pair_v3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Re_Pair_v3.Presentation.Controllers
{
    //[Authorize]
    public class UserAddressController : ApiController
    {
        private UserAddressServices _userAddresssService;

        public UserAddressController(UserAddressServices userAddressService)
        {
            _userAddresssService = userAddressService;
        }

        [Route("api/useraddress")]
        [HttpGet]
        public IList<UserAddressDTO> Get()
        {
            return _userAddresssService.List(User.Identity.Name);
        }

        [Route("api/useraddress/search/{lastname}")]
        [HttpGet]
        public IList<UserAddressDTO> GetByLastName(string lastname)
        {
            return _userAddresssService.FindByLastName(lastname);
        }


        public IHttpActionResult Get(int id)
        {

            var userAddress = _userAddresssService.FindById(id, User.Identity.Name);

            if (userAddress != null)
            {
                return Ok(userAddress);
            }

            return Unauthorized();

        }


    }
}
