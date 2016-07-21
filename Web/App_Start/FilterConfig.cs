using System;
using System.Web;
using System.Web.Mvc;

namespace MediaDatabase.Web.Config
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (null == filters)
                throw new ArgumentNullException("filters");

            filters.Add(new HandleErrorAttribute());
        }
    }
}
