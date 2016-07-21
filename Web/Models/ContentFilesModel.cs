using MediaDatabase.Database.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaDatabase.Web.Models
{
    public class ContentFilesModel
    {
        public ContentFilesModel(int volumeId, int page, string search, IEnumerable<SelectListItem> volumes, IEnumerable<ContentFile> contentFiles)
        {
            VolumeId = volumeId;
            Page = page;
            Search = search;
            Volumes = volumes;
            ContentFiles = contentFiles;
        }

        public int VolumeId
        {
            get;
            private set;
        }

        public int Page
        {
            get;
            private set;
        }

        public string Search
        {
            get;
            private set;
        }

        public IEnumerable<SelectListItem> Volumes
        {
            get;
            private set;
        }

        public IEnumerable<ContentFile> ContentFiles
        {
            get;
            private set;
        }
    }
}