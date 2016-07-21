using MediaDatabase.Database.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediaDatabase.Web.Models
{
    public class ScanRequestsModel
    {
        public ScanRequestsModel(IEnumerable<ScanRequest> scanRequests)
        {
            ScanRequests = scanRequests;
        }

        public IEnumerable<ScanRequest> ScanRequests
        {
            get;
            private set;
        }
    }
}