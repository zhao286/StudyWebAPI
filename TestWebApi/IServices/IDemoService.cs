using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.IServices
{
   public interface IDemoService
    {
        List<Demo> List();
    }
}
