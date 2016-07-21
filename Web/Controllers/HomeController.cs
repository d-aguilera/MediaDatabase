using MediaDatabase.Common;
using MediaDatabase.Database;
using MediaDatabase.Database.Entities;
using MediaDatabase.Web.Models;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MediaDatabase.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Scan()
        {
            var drives = new List<SelectListItem>();
            drives.Add(CreateNullSelectListItem());
            drives.AddRange(
                DriveInfo.GetDrives()
                .OrderBy(o => o.Name)
                .Select(o => CreateSelectListItem(o, false))
                .ToArray()
            );

            var model = new ScanModel(drives);

            return View(model);
        }

        [HttpPost]
        public ActionResult Scan(string path)
        {
            using (var context = new DataGateway())
            {
                var scanRequest = new ScanRequest
                {
                    Status = (int)TaskStatus.Created,
                    VolumeName = path,
                };

                context.Insert(scanRequest);

                return RedirectToAction("ScanProgress", "Home");
            }
        }

        [HttpPost]
        public ActionResult Cancel()
        {
            using (var sc = new ServiceController("MediaDatabase"))
            {
                try
                {
                    sc.ExecuteCommand(Common.Constants.Service.CancelCommand);
                }
                catch (InvalidOperationException)
                {
                }
            }
            return RedirectToAction("ScanProgress", "Home");
        }

        public ActionResult ScanProgress()
        {
            return View();
        }

        static SelectListItem CreateNullSelectListItem()
        {
            return new SelectListItem { Text = Resources.PleaseSelectItem, Value = "0", Selected = true };
        }

        static SelectListItem CreateSelectListItem(DriveInfo o, bool selected)
        {
            string size;
            string volumeLabel;
            if (o.IsReady)
            {
                var tuple = Helpers.FormatBytes(o.TotalSize);
                var num = tuple.Item1;
                var unit = tuple.Item2;
                size = string.Format(CultureInfo.InvariantCulture, "{0:0.00} {1}", num, unit);
                volumeLabel = o.VolumeLabel;
            }
            else
            {
                size = "not ready";
                volumeLabel = null;
            }
            var parts = new[]
            {
                o.Name,
                volumeLabel,
                o.DriveType + "",
                size,
            };
            var text = string.Join(Resources.Separator, parts.Where(p => !string.IsNullOrEmpty(p)).ToArray());
            var value = o.Name;
            return new SelectListItem { Text = text, Value = value, Selected = selected };
        }
    }
}
