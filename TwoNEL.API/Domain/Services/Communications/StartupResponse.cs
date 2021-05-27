﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoNEL.API.Domain.Models;

namespace TwoNEL.API.Domain.Services.Communications
{
    public class StartupResponse : BaseResponse<Models.Startup>
    {
        public StartupResponse(Models.Startup resource) : base(resource)
        {
        }

        public StartupResponse(string message) : base(message)
        {
        }
    }
}
