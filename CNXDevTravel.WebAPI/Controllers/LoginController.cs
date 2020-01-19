using CNXDevTravel.Model.RequestModel;
using CNXDevTravel.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNXDevTravel.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ServiceFactory _service;
        public LoginController(ServiceFactory service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] LoginModel loginModel)
        {
            var result = _service.User().Authen(loginModel);
            return Ok(result);
        }
    }
}
