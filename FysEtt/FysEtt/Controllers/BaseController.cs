using FysEtt.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FysEtt.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected readonly UnitOfWork _uow;

        public BaseController()
        {
            _uow = new UnitOfWork();
        }

    }
}
