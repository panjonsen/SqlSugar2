using Helper;

namespace HuihuWebApi.Controllers
{
    public class MainMidder
    {
        public readonly RequestDelegate requestDalegate;

        public MainMidder(RequestDelegate requestDalegate)
        {
            this.requestDalegate = requestDalegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //过滤无用的访问 只支持开放的访问路径

            if (httpContext.Request.Path.Value == null)
            {
                await httpContext.Response.WriteAsync(HttpResultHelper.ErrorByC("000001"));
                return;
            }
            var path = httpContext.Request.Path.Value.Split("/");

            if (path == null)
            {
                await httpContext.Response.WriteAsync(HttpResultHelper.ErrorByC("000001"));
                return;
            }
            if (path.Length < 3)
            {
                await httpContext.Response.WriteAsync(HttpResultHelper.ErrorByC("000001"));
                return;
            }

            //path[0]=""  这下标是个空  无视掉一下即可

            switch (path[1])
            {
                case "api":
                    switch (path[2])
                    {
                        case "V1":
                            //这个访问路径放行 其他路径不放行
                            await requestDalegate.Invoke(httpContext);
                            //到下一个中间件去
                            return;
                            break;

                        default:
                            break;
                    }

                    break;

                default:
                    break;
            }

            await httpContext.Response.WriteAsync(HttpResultHelper.ErrorByC("000001"));
            return;//不在继续执行到其他中间件
        }
    }
}