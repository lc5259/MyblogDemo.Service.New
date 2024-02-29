using Blog.Service.New.Application.Auth.Dtos;
using Blog.Service.New.Application.System.Services;
using Blog.Service.New.Core.Const;
using Blog.Service.New.Core.Current;
using Blog.Service.New.Core.EFCore;
using Blog.Service.New.Core.Entities;
using Blog.Service.New.Core.Jwt;
using Blog.Service.New.Core.Redis;
using Furion.DatabaseAccessor;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.New.Application.Auth
{
    [ApiDescriptionSettings(Name = "System")]
    [AllowAnonymous] //允许匿名访问，不用鉴权授权
    public class AuthService : IDynamicApiController  //动态api接口，服务层不用再注册了
    {
        private readonly IRepository<SysRole> _repositorySysRole;
        private readonly EntityManager _entityManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDatabase _redis;

        public AuthService(IRepository<SysRole> repositorySysRole, EntityManager entityManager,
                            IHttpContextAccessor httpContextAccessor,
                            RedisHelper redisHelper)
        {
            this._repositorySysRole = repositorySysRole;
            this._entityManager = entityManager;
            this._httpContextAccessor = httpContextAccessor;
            _redis = redisHelper.GetDatabase();
        }


        /// <summary>
        /// 获取公钥
        /// </summary>
        /// <returns></returns>
        [HttpGet("public_key"), AllowAnonymous]
        public string GetPublicKey()
        {
            return RSAUtil.GetKey();
        }


        [UnitOfWork]
        [HttpPost]
        public async Task<LoginResponse> Signup(LoginRequest loginRequest)
        {
            //模拟下前端接口调用，先调用接口获取公钥
            //loginRequest.publicKey =  RSAUtil.GetKey();


            try
            {
                Log.Information("开始进行注册操作！");

                if (string.IsNullOrEmpty(loginRequest.code) || string.IsNullOrEmpty(loginRequest.password))
                {
                    throw Oops.Oh("请输入完整用户信息！");
                }

                var model = loginRequest;
                //密码进行加密
                //model.password = RSAUtil.Decrypt(model.password, model.publicKey);
                //注册时候默认为系统管理元用户
                var role = this._repositorySysRole.Find(Roles.SystemManage);
                var user = new UserInfo()
                {
                    id = Guid.NewGuid().ToString(),
                    code = model.code,
                    password = model.password,
                    name = model.code.Split("@")[0],
                    mailbox = model.code,
                    roleid = role.id.ToString(),
                    roleid_name = role.name,
                    statecode = true,
                    statecode_name = "启用"
                };
                this._entityManager.Create<UserInfo>(user);
                //await Db.GetRepository<UserInfo>().Entities.AddAsync(user);
                var _authUser = new AuthUser()
                {
                    id = user.id,
                    name = user.name,
                    code = user.code,
                    roleid = user.roleid,
                    roleid_name = user.roleid_name,
                    user_infoid = user.id.ToString(),
                    is_lock = false,
                    last_login_time = DateTime.Now,
                    password = model.password
                };
                this._entityManager.Create<AuthUser>(_authUser);
                //await Db.GetRepository<AuthUser>().Entities.AddAsync(_authUser);

                Log.Information($"用户{user.name}注册成功！");

                return new LoginResponse()
                {
                    result = true,
                    message = "注册成功",
                    level = LoginMesageLevel.Success.ToString()
                };

                
            }
            catch (Exception e)
            {
                Log.Error($"用户：注册失败");
                return new LoginResponse()
                {
                    result = false,
                    message = "注册失败",
                    level = LoginMesageLevel.Fail.ToString()
                };

            }



        }

        public async Task<LoginResponse> Login(LoginRequest model)
        {

            // 联合第三方登录。 这个待定，后面进行完善，使用二维码方式。
            if (model.third_party_login != null)
            {
                //var loginStrategy = ServiceContainer
                //    .ResolveAll<IThirdPartyLoginStrategy>()
                //    .First(item => item.GetName().Equals(model.third_party_login.type, StringComparison.OrdinalIgnoreCase));
                //AssertUtil.IsNull(loginStrategy, $"根据{model.third_party_login.type}未找到登录策略");
                //return loginStrategy.Login(model.third_party_login.param);
            }       
            var code = model.code;
            var pwd = model.password;
            var publicKey = model.publicKey;
            AuthUser authUser =await Db.GetRepository<AuthUser>().FirstOrDefaultAsync(u => u.code == code);
       
            //var authUser = Manager.QueryFirst<AuthUser>("SELECT * FROM auth_user WHERE lower(code) = lower(@code)", new Dictionary<string, object>() { { "@code", code } });

            if (authUser == null)
            {
                return new LoginResponse() { result = false, message = "用户名或密码错误" };
            }

            if (authUser.is_lock.Value)
            {
                return new LoginResponse() { result = false, message = "用户已被锁定，请联系管理员" };
            }

            //if (string.IsNullOrEmpty(pwd) ||
            //    string.IsNullOrEmpty(publicKey) ||
            //    !string.Equals(authUser.password, RSAUtil.Decrypt(pwd, publicKey))
            //    )
            //{

            //}

            
            if (authUser.code != code || !string.Equals(authUser.password, pwd))
            {
                return new LoginResponse() { result = false, message = "密码错误，请重新输入" };
            }

            //将当前登录的用户信息 存入 redis中
            string currentUserStr = _redis.StringGet("CurrentUser");

            CurrentUserModel currentUser = new CurrentUserModel()
            {
                Id = authUser.id,
                Code = authUser.code,
                Name = authUser.name
            };

            bool SerizlResult = _redis.StringSet("CurrentUser", JSON.Serialize(currentUser));
            if (!SerizlResult)
            {
                return new LoginResponse() { result = false, message = "用户信息缓存失败，请检查缓存服务器！" };
            }


            var context = _httpContextAccessor.HttpContext;
            if (authUser.try_times > 0)
            {
                authUser.try_times = 0;
            }
            authUser.last_login_time = DateTime.Now;
            Db.GetRepository<AuthUser>().Update(authUser);
            //Manager.Update(authUser);

            // 返回登录结果、用户信息、用户验证票据信息
            var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
            {
                { "UserId", authUser.id },  // 存储Id
                { "Account",authUser.code }, // 存储用户名
            });

            // 获取刷新 token
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken);
            // 设置响应报文头
            context!.Response.Headers["access-token"] = accessToken;
            context.Response.Headers["x-access-token"] = refreshToken;

            var oUser = new LoginResponse
            {
                result = true,
                userName = code,
                token = new ComplexToken() { AccessToken = accessToken, RefreshToken = refreshToken },
                //token = null,
                userId = authUser.user_infoid,
                message = "登录成功"
            };
            return oUser;
        }
    }
}
