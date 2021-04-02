using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
    [Table("Demo")]
    public class Demo
    {
        [Key]
        public int tid { get; set; }
        public string tname { get; set; }
        [Write(false)]
        public byte isNull { get; set; }

        public byte typeid { get; set; }

    }
}
