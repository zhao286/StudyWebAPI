using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.DBContexts
{
    /// <summary>
    /// 数据库上下文，模拟数据库相关业务
    /// </summary>
    public class DBContext
    {
        /// <summary>
        /// 用户信息，模拟数据库表
        /// </summary>
        public static List<User> Users = new List<User>()
        {
            new User(){ ID=1001, Email="zhansan@qq.com", Password="zhansan123", UserName="张三", RegTime=DateTime.Now, LastLoginTime = DateTime.Now, Status = true},
            new User(){ ID=1002, Email="lisi@qq.com", Password="lisi123", UserName="李四", RegTime=DateTime.Now, LastLoginTime = DateTime.Now, Status = false},
            new User(){ ID=1003, Email="wangwu@qq.com", Password="wangwu123", UserName="王五", RegTime=DateTime.Now, LastLoginTime = DateTime.Now, Status = true},
        };
    }
}
