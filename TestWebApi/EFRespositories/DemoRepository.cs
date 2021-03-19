using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.DBContexts;
using TestWebApi.IRespositories;
using TestWebApi.Models;

namespace TestWebApi.EFRespositories
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
            Console.WriteLine("现在使用的是 EF 的用户仓储。");
        }

        public List<Demo> List()
        {
            DynamicParameters param = new DynamicParameters();
            List<int> tid = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                tid.Add(i);
            }

            List<string> lstSQL = new List<string>() {
                "select * from demo where tid = '1'",
                "select * from demo where tid = '2'",
                "select * from demo where tid = '3';;;;;",
                "select * from demo where tid = '4'",
                "select * from demo where tid in(1,7,8,9)"
            };

            //List<Demo> rt = _conn.Query<Demo>("select * from demo where tid in @tid", new { tid = tid }).ToList();
            List<Demo> rt = _conn.Query<Demo>("select * from demo where 1<>1").OrderBy(x=>x.tid).ToList();

            var mr = _conn.QueryMultiple(string.Join(";",lstSQL));

            List<Demo> rtt = new List<Demo>();
            while (!mr.IsConsumed)
            {
                rtt.AddRange(mr.Read<Demo>().ToList());
            }
            var ab = rtt.Distinct<Demo>(new DemoComparer()).ToList();
            return rt;
        }

        public class DemoComparer : IEqualityComparer<Demo>
        {
            public bool Equals(Demo x, Demo y)
            {
                if (x == null)
                    return y == null;
                return x.tid == y.tid;
            }

            public int GetHashCode(Demo obj)
            {
                if (obj == null)
                    return 0;
                return obj.tid.GetHashCode();
            }
        }
    }
}
