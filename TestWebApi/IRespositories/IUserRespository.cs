using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.IRespositories
{
    /// <summary>
    /// 仓储接口，用于定义用户相关的操作。
    /// </summary>
    public interface IUserRespository
    {
        int Add(User user);
        int Update(User user);
        User GetByID(int id);
        User GetByEmail(string email);
        List<User> List();
    }
}
