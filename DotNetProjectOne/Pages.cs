using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DotNetProjectOne
{
    public class Pages
    {
        private StartPage _startPage = StartWindow._startPage;
        private SearchPage _searchPage;
        private FilmPage _filmpage;

        public UserControl searchPage
        {
            get
            {
                if (_searchPage == null)
                    _searchPage = new SearchPage();
                return _searchPage;
            }
        }
        public UserControl startPage
        {
            get
            {
                return _startPage;
            }
        }
        public UserControl filmPage
        {
            get
            {
                if (_filmpage == null)
                    _filmpage = new FilmPage();
                return _filmpage;
            }
        }
    }
}
