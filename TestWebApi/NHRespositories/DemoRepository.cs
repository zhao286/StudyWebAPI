using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TestWebApi.IRespositories;
using TestWebApi.Models;

namespace TestWebApi.NHRespositories
{
    /// <summary>
    /// 仓储，用户相关操作
    /// </summary>
    public class DemoRepository : IDemoRespository
    {
        private readonly IDbConnection _conn = null;
        public DemoRepository(IDbConnection conn)
        {
            _conn = conn;
            Console.WriteLine("现在使用的是 NH 的用户仓储。");
        }

        public List<Demo> List()
        {
             return _conn.Query<Demo>("select * from demo").ToList();
        }
    }
}
