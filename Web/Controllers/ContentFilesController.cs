using MediaDatabase.Database;
using MediaDatabase.Database.Entities;
using MediaDatabase.Web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediaDatabase.Web.Controllers
{
    public class ContentFilesController : Controller
    {
        public ActionResult Index(int? vid, int? p, string search)
        {
            var volumeId = vid ?? 0;

            if (volumeId < 0)
                throw new ArgumentOutOfRangeException("vid");

            var page = p ?? 1;

            if (page < 1)
                throw new ArgumentOutOfRangeException("p");

            return Index(volumeId, page, search);
        }

        ActionResult Index(int volumeId, int page, string search)
        {
            var take = 25;
            var skip = page * take - take;
            using (var context = new DataGateway())
            {
                var contentFiles = context.Set<ContentFile>()
                    .Include(o => o.Content)
                    .Where(o => o.Volume.Id == volumeId)
                    ;

                if (!string.IsNullOrWhiteSpace(search))
                    contentFiles = contentFiles
                        .Where(o => o.Name.Contains(search) || o.Path.Contains(search))
                        ;

                contentFiles = contentFiles
                    .OrderBy(o => o.Id)
                    .Skip(skip)
                    .Take(take)
                    ;

                var volumes = new List<SelectListItem>();
                volumes.Add(CreateNullSelectListItem());
                volumes.AddRange(
                    context.Set<Volume>()
                    .Include(o => o.Partition.Medium)
                    .OrderBy(o => o.Partition.Medium.Caption)
                    .ThenBy(o => o.Caption)
                    .ThenBy(o => o.Id)
                    .ToArray() // necessary
                    .Select(o => CreateSelectListItem(o, volumeId))
                    .ToArray()
                );

                var model = new ContentFilesModel(volumeId, page, search, volumes, contentFiles.ToArray());

                return View(model);
            }
        }

        SelectListItem CreateNullSelectListItem()
        {
            return CreateSelectListItem(Resources.PleaseSelectItem, "0", true);
        }

        SelectListItem CreateSelectListItem(Volume o, int selectedVolumeId)
        {
            var text = o.Partition.Medium.Caption + Resources.Separator + o.Caption;
            var value = "" + o.Id;
            var selected = o.Id == selectedVolumeId;
            return CreateSelectListItem(text, value, selected);
        }

        static SelectListItem CreateSelectListItem(string text, string value, bool selected)
        {
            return new SelectListItem { Text = text, Value = value, Selected = selected };
        }
    }
}