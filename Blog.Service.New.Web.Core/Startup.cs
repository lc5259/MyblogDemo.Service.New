using Blog.Service.New.Core.Redis;
using Blog.Service.New.Web.Core.Handlers;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Blog.Service.New.Web.Core;

public class Startup : AppStartup
{
    //服务注册
    public void ConfigureServices(IServiceCollection services)
    {
        //用于启用或禁用 Npgsql 客户端与 Postgres 服务器之间的时间戳行为。它并不会直接修改 Postgres 的时区设置。
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

        services.AddConsoleFormatter();
        //services.AddJwt<JwtHandler>(); //鉴权授权。这是默认授权方式，需要授权的方法需要添加 [Ahthorize] 特性
        services.AddJwt<JwtHandler>(enableGlobalAuthorize:true); //全局授权，每个接口都必须授权才能访问，无需添加特性

        services.AddCorsAccessor();

        //配置redis
        string _connectStr = App.Configuration["Redis:Connection"].ToString();
        string _instanceName = App.Configuration["Redis:InstanceName"].ToString();
        int _defaultDB = int.Parse( App.Configuration["Redis:DefaultDB"]);
        services.AddSingleton(new RedisHelper(_connectStr, _instanceName, _defaultDB));


        services.AddControllers()
                .AddInjectWithUnifyResult();
    }

    //添加中间件
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication(); //鉴权
        app.UseAuthorization(); //授权

        app.UseInject(string.Empty);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
