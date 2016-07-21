using MediaDatabase.Database;
using MediaDatabase.Database.Entities;
using MediaDatabase.Web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediaDatabase.Web.Controllers
{
    public class ScanRequestsController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new DataGateway())
            {
                var scanRequests = context.Set<ScanRequest>()
                    .OrderBy(o => o.Id)
                    ;

                var model = new ScanRequestsModel(scanRequests.ToArray());

                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
            using (var context = new DataGateway())
            {
                var scanRequest = context.Set<ScanRequest>()
                    .Single(o => o.Id == id)
                    ;
                return View(scanRequest);
            }
        }
    }
}