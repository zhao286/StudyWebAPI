using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
    public class Demo
    {
        public int tid { get; set; }
        [Write(false)]
        public string tname { get; set; }

        public byte isNull { get; set; }

        public byte typeid { get; set; }

    }
}
