using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DotNetProjectOne
{
  public  class Img
    {
        public Img(string value, string year, string name, string director)
      { Str = value; Name = name; Director = director; Year = year; }
        public string Str { get; set; }
        public string Director { get; set; }
        public string Year { get; set; }
        public string Name { get; set; }
    }

}
