using Blog.Service.New.Application.Auth.Dtos;
using Blog.Service.New.Core.Const;
using Blog.Service.New.Core.EFCore;
using Blog.Service.New.Core.Entities;
using Furion.DatabaseAccessor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.New.Application.Auth
{
    [AllowAnonymous]
    public class AuthService : IDynamicApiController  //动态api接口，服务层不用再注册了
    {
        private readonly IRepository<SysRole> _repositorySysRole;
        private readonly EntityManager _entityManager;

        public AuthService(IRepository<SysRole> repositorySysRole, EntityManager entityManager )
        {
            this._repositorySysRole = repositorySysRole;
            this._entityManager = entityManager;
        }

        [UnitOfWork]
        [HttpPost]
        public async Task<LoginResponse> Signup(LoginRequest loginRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(loginRequest.code) || string.IsNullOrEmpty(loginRequest.password))
                {
                    throw Oops.Oh("请输入完整用户信息！");
                }

                var model = loginRequest;
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

                return new LoginResponse()
                {
                    result = true,
                    message = "注册成功",
                    level = LoginMesageLevel.Success.ToString()
                };
            }
            catch (Exception)
            {
                return new LoginResponse()
                {
                    result = false,
                    message = "注册失败",
                    level = LoginMesageLevel.Fail.ToString()
                };
                
            }
           


        }
    }
}
