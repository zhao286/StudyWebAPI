using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.IRespositories;
using TestWebApi.NHRespositories;
using TestWebApi.Models;
using TestWebApi.IServices;

namespace TestWebApi.Services
{
    /// <summary>
    /// 用户相关的逻辑处理
    /// </summary>
    public class UserService:IUserService
    {
        private readonly IUserRespository _userRepository = null;

        public UserService(IUserRespository userRespository)
        {
            this._userRepository = userRespository;
        }
        
        public bool Reg(User user)
        {
            //1.检查
            if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }

            //2.记录用户信息
            user.RegTime = DateTime.Now;
            user.Status = true;

            //2.保存
            int cnt = _userRepository.Add(user);

            return cnt > 0;
        }
        
        public bool Login(User user)
        {
            //1.检查
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }
            //2.按邮箱获取信息
            var taget = _userRepository.GetByEmail(user.Email);
            if(taget == null)
            {
                return false;
            }
            //3.密码错误
            if (!taget.Password.Equals(user.Password))
            {
                return false;
            }
            //4.更新信息
            taget.LastLoginTime = DateTime.Now;
            _userRepository.Update(user);

            return true;
        }

        public User GetByID(int id)
        {
            return _userRepository.GetByID(id);
        }

        public bool ExistsByEmail(string email)
        {
            return _userRepository.GetByEmail(email) != null;
        }

        public List<User> List()
        {
            return _userRepository.List();
        }
    }
}
