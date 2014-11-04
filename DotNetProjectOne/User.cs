using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetProjectOne
{
   public class UserComment
   {
       public UserComment(string login, string comment)
      { Login = login; Comment=comment;}
        public string Login { get; set; }
        public string Comment { get; set; }

    }
}
