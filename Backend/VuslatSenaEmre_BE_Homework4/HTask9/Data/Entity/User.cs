using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HTask9.Data.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}