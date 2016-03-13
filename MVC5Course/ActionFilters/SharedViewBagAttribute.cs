using System.Web.Mvc;

namespace MVC5Course
{
    public class SharedViewBagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.HelloWorld = "你好世界";

            base.OnActionExecuting(filterContext);
        }
    }
}