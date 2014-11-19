using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetProjectOne
{
   public class ObjectClasses
    {
       public class Actor
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Photo { get; set; }
        }

        public class Writer
        {
            public string WName { get; set; }
            public string WSurname { get; set; }
        }
        public class Producer
        {
            public string PName { get; set; }
            public string PSurname { get; set; }
        }

        public class Composer
        {
            public string CName { get; set; }
            public string CSurname { get; set; }
        }
        public class ALanguage
        {
            public string LName { get; set; }
        }
        public class Genre
        {
            public string GName { get; set; }
        }
    }
}
