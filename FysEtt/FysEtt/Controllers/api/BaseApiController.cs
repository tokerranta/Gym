﻿using FysEtt.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FysEtt.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly UnitOfWork _uow;

        public BaseApiController()
        {
            _uow = new UnitOfWork();
        }
    }
}
