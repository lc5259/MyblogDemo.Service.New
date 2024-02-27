using Blog.Service.New.Core.Current;
using Blog.Service.New.Core.Entities;
using Blog.Service.New.Core.Entities.Base;
using Blog.Service.New.Core.Redis;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.JsonSerialization;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blog.Service.New.Core.EFCore
{
    public class EntityManager :  ITransient
    {
        private readonly IDatabase _redis;
        private readonly RedisHelper _redisHelper;

        public EntityManager(RedisHelper  redisHelper)
        {
            this._redis = redisHelper.GetDatabase();
        }

        public void BulkCreate<TEntity>(List<TEntity> dataList) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public void BulkCreate(string tableName, string primaryKeyName, DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public void BulkCreateOrUpdate<TEntity>(List<TEntity> dataList, List<string> updateFieldList = null) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public void BulkCreateOrUpdate(string tableName, string primaryKeyName, DataTable dataTable, List<string> updateFieldList = null)
        {
            throw new NotImplementedException();
        }

        public void BulkDelete<TEntity>(List<TEntity> dataList) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public void BulkUpdate<TEntity>(List<TEntity> dataList) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public void BulkUpdate(string tableName, string primaryKeyName, DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public string Create(BaseEntity entity, bool usePlugin = true)
        {
            throw new NotImplementedException();
        }

        public void Create<T>(T entity, bool usePlugin = true) where T : BaseEntity, new()
        {
            bool retutnValue = false;
            //设置默认值

            //从redis中取出当前登录的用户信息.取出的是一个json字符串
            string currentUserStr =  _redis.StringGet("CurrentUser");
            if (!string.IsNullOrEmpty(currentUserStr))
            {
                CurrentUserModel currentUser = JSON.Deserialize<CurrentUserModel>(currentUserStr);
                entity.created_by = currentUser.Id;
                entity.created_by_name = currentUser.Code;
           
              
                entity.updated_by = currentUser.Id;
                entity.updated_by_name = currentUser.Code; 

            }
                
            var repository = Db.GetRepository<T>();
            var result = repository.Entities.Add(entity);

            
        }

        public int Delete(string typeName, string id)
        {
            throw new NotImplementedException();
        }

        public int Delete(BaseEntity obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(BaseEntity[] objArray)
        {
            throw new NotImplementedException();
        }

        public int DeleteByWhere(string typeName, string where, Dictionary<string, object> paramList = null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Execute(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlScript(string sqlFile)
        {
            throw new NotImplementedException();
        }

        public void ExecuteTransaction(Action func)
        {
            throw new NotImplementedException();
        }

        public T ExecuteTransaction<T>(Func<T> func)
        {
            throw new NotImplementedException();
        }

        public DataTable Query(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(string sql, object param, string orderby, int pageSize, int pageIndex) where T : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(string sql, object param, string orderby, int pageSize, int pageIndex, out int recordCount) where T : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(IList<string> ids) where T : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public int QueryCount(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public T QueryFirst<T>(string id) where T : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public T QueryFirst<T>(string sql, object param = null) where T : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public string Save(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
