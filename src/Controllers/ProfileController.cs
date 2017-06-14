﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model = PortfolioApi.Models.Profile;
using PortfolioApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : PortfolioController
    {
        public ProfileController(PortfolioContext context):base(context)
        {
        }

        //https://github.com/domaindrivendev/Swashbuckle.AspNetCore
        //https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md
        // GET api/profile
        [HttpGet, AllowAnonymous]
        public Model Get()
        {
            if (_context.Profiles.Any())
            {
                return _context.Profiles.First();
            }
            return null;
        }
    }
}
