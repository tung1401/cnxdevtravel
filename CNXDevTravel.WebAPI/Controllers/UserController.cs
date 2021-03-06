﻿using CNXDevTravel.Model.RequestModel;
using CNXDevTravel.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNXDevTravel.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ServiceFactory _service;
        public UserController(ServiceFactory service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var username = User.Identity.Name;
            return Ok(username);
        }

    }
}
