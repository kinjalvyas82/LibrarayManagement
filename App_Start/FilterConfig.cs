using System;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public class GlobalFilterCollection
        {
            internal void Add(HandleErrorAttribute handleErrorAttribute)
            {
                throw new NotImplementedException();
            }
        }

        internal static void RegisterGlobalFilters(object filters)
        {
            throw new NotImplementedException();
        }
    }
}
