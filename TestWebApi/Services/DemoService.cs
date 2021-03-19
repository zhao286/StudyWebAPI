using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.IRespositories;
using TestWebApi.NHRespositories;
using TestWebApi.Models;
using TestWebApi.IServices;
using Microsoft.Extensions.Caching.Memory;

namespace TestWebApi.Services
{
    /// <summary>
    /// 用户相关的逻辑处理
    /// </summary>
    public class DemoService : IDemoService
    {
        private readonly IDemoRespository _demoRepository = null;
        private readonly IMemoryCache _cache = null;
        private static string guid = null;
        public DemoService(IDemoRespository demoRepository, IMemoryCache memory)
        {
            this._demoRepository = demoRepository;
            _cache = memory;

            guid = Guid.NewGuid().ToString().Replace("-", "");
            _cache.Set(guid, new Demo() {  tid = 111, tname = "zhaogang", typeid =2}, new DateTimeOffset(DateTime.Now.AddHours(1)));
        }

        public List<Demo> List()
        {
            Demo query = _cache.Get<Demo>(1);
            Demo query1 = _cache.Get<Demo>(guid);
            return _demoRepository.List();
        }
    }
}
