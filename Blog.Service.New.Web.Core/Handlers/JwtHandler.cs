using Furion.Authorization;
using Furion.DataEncryption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Blog.Service.New.Web.Core.Handlers;

public class JwtHandler : AppAuthorizeHandler
{
    //<summary>
    /// 验证管道，也就是验证核心代码
    /// </summary>
    /// <param name="context"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public override Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
    {
        //这里进行授权。这里可以请求数据库判断是否有访问此页面的权限
        var asgg = httpContext.Request;
        string code = httpContext.Request.Path.Value!.Replace("/api/", "").Replace("/", ":");
        // 这里写您的授权判断逻辑，授权通过返回 true，否则返回 false
        return Task.FromResult(true);
    }

    /// <summary>
    /// 重写 Handler 添加自动刷新收取逻辑
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task HandleAsync(AuthorizationHandlerContext context)
    {
        // 自动刷新 token
        if (JWTEncryption.AutoRefreshToken(context, context.GetCurrentHttpContext()))
        {
            await AuthorizeHandleAsync(context);
        }
        else context.Fail();    // 授权失败
    }
}
