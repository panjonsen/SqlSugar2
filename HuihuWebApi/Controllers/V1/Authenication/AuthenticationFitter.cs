using HuihuWebApi.Controllers.V1.Authenication.MyAttribute;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HuihuWebApi.Controllers.V1.Authenication
{
    public class AuthenticationFitter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //找控制器 或者 方法 的一些特性等等很多属性
            ControllerActionDescriptor? controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            string[] routeArr = controllerActionDescriptor.AttributeRouteInfo.Template.Split("/");

            //	"api/V1/User/CreateUser"

            

            //如果不是这个路径的就放行 只需要对指定的地方做鉴权处理
            // NotAuthenticationAttr  如果某个方法不需要鉴权 就加上这个特性 过滤
            //后续在考虑是否对控制器加特性 来做整个控制器的过滤鉴权
            if (routeArr[0] != "api" && routeArr[1] != "V1")
            {
                await next();
            }

            if (controllerActionDescriptor != null)
            {
                //
                var hasNotAuthenticationAttr = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(NotAuthenticationAttr), false).Any();

                //如果找到这个特性就跳过鉴权
                if (hasNotAuthenticationAttr)
                {
                    await next();
                }
            }

            //开始鉴权
            Console.WriteLine("访问接口前代码");

            await next();

            Console.WriteLine("访问接口后代码");
        }
    }
}