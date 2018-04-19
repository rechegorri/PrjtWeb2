using System.Web;
using System.Web.Mvc;

namespace PrjtWeb2_cadastro_ocorrencia
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
