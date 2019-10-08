using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaJobs.Controllers
{
    public class VagasController : Controller
    {
        // GET: Vagas
        public ActionResult Index()
        {
            return View();
        }
    }
}