using MediaDatabase.Database.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediaDatabase.Web.Models
{
    public class MediaModel
    {
        public MediaModel(IEnumerable<Medium> media)
        {
            Media = media;
        }

        public IEnumerable<Medium> Media
        {
            get;
            private set;
        }
    }
}