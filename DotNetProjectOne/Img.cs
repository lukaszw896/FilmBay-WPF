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
        public Img(string value, Image img, string name)
      { Str = value; Image = img; Name = name; }
        public string Str { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
    }

}
