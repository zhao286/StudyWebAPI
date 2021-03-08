using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.DBContexts;
using TestWebApi.IRespositories;
using TestWebApi.Models;

namespace TestWebApi.NHRespositories
{
    /// <summary>
    /// 仓储，用户相关操作
    /// </summary>
    public class UserRepository:IUserRespository
    {
        public UserRepository()
        {
            Console.WriteLine("现在使用的是 NH 的用户仓储。");
        }
        public int Add(User user)
        {
            DBContext.Users.Add(user);
            return 1;
        }

        public int Update(User user)
        {
            var tagUser = DBContext.Users.Single(x => x.Email.Equals(user.Email,StringComparison.InvariantCultureIgnoreCase));
            tagUser.Password = user.Password;
            tagUser.UserName = user.UserName;
            tagUser.Status = user.Status;
            tagUser.LastLoginTime = DateTime.Now;

            return 1;
        }

        public User GetByID(int id)
        {
            return DBContext.Users.SingleOrDefault(x => x.ID == id);
        }

        public User GetByEmail(string email)
        {
            return DBContext.Users.SingleOrDefault(x => x.Email.Equals(email,StringComparison.InvariantCultureIgnoreCase));
        }

        public List<User> List()
        {
            return DBContext.Users;
        }
    }
}
