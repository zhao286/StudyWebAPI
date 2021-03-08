using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.IServices
{
   public interface IUserService
    {
        bool Reg(User user);
        bool Login(User user);
        User GetByID(int id);
        bool ExistsByEmail(string email);
        List<User> List();
    }
}
