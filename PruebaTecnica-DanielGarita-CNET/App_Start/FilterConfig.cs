using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica_DanielGarita_CNET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
