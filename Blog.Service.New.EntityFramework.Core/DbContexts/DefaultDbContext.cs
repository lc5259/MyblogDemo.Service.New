﻿using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace Blog.Service.New.EntityFramework.Core.DbContexts;

[AppDbContext("ConnectionStrings:PostgreSQLConnectionString", DbProvider.Npgsql)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {

    }

    //一下方式启用懒加载
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseLazyLoadingProxies()
    //                  .UseSqlServer(DbProvider.GetConnectionString<DefaultDbContext>());

    //    base.OnConfiguring(optionsBuilder);
    //}
}
