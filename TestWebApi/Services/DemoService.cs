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
    public class DemoService : IDemoService
    {
        private readonly IDemoRespository _demoRepository = null;

          public DemoService(IDemoRespository demoRepository)
        {
            this._demoRepository = demoRepository;
        }

        public List<Demo> List()
        {
            return _demoRepository.List();
        }
    }
}
