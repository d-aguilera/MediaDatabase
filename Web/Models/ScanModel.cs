using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediaDatabase.Web.Models
{
    public class ScanModel
    {
        public ScanModel(IEnumerable<SelectListItem> drives)
        {
            Drives = drives;
        }

        public IEnumerable<SelectListItem> Drives
        {
            get;
            private set;
        }
    }
}