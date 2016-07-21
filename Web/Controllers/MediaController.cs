using MediaDatabase.Database;
using MediaDatabase.Database.Entities;
using MediaDatabase.Web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediaDatabase.Web.Controllers
{
    public class MediaController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new DataGateway())
            {
                var media = context.Set<Medium>()
                    .Include(o => o.MediaType)
                    .OrderBy(o => o.Caption)
                    //.ThenBy(o => o.Id)()
                    ;

                var model = new MediaModel(media.ToArray());

                return View(model);
            }
        }
    }
}