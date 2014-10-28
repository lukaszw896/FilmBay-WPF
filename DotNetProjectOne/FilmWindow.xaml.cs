using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for FilmWindow.xaml
    /// </summary>
    public partial class FilmWindow : Window
    {
        public FilmWindow()
        {
            InitializeComponent();
        }

        private void CheckIfNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }

        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int value;

        
          

            if (string.IsNullOrWhiteSpace(this.Title.Text))
            {
                MessageBox.Show("TextBox is empty");
            }
            else if (string.IsNullOrWhiteSpace(this.DName.Text))
            {
                MessageBox.Show("Must give name of Director!");
            }
            else if (string.IsNullOrWhiteSpace(this.DSubName.Text))
            {
                MessageBox.Show("Must give subname of Director!");
            }
            else if (string.IsNullOrWhiteSpace(this.Language.Text))
            {
                MessageBox.Show("Language is important");
            }
            else if (string.IsNullOrWhiteSpace(this.Price.Text))
            {
                MessageBox.Show("Must Give Price");
            }
            else if (string.IsNullOrWhiteSpace(this.Duration.Text))
            {
                MessageBox.Show("Must give duration in minutes");
            }
            /*
             if (int.TryParse(Price.Text, out value))
            {
                if (value ==0)
                    MessageBox.Show("Price can't be 0");
            }
             if (int.TryParse(Month.Text, out value))
            {
                if (value >12)
                    MessageBox.Show("Invalid Month");
            }
              if (int.TryParse(Day.Text, out value))
            {
                 if (value >31 )
                    MessageBox.Show("Invalid Day Number");
            }
              if (int.TryParse(Year.Text, out value))
              {
                  if (value < 1890 && value!=1111)
                      MessageBox.Show("Films didn't exist back then");
              }
            */
              else
              {
                 MessageBox.Show("All is fine");
                 
                  film_table dane = new film_table();
           
                  dane.director_name = DName.Text;
                  dane.director_surname = DSubName.Text;
                  dane.film_price = double.Parse(Price.Text);
                  if (Studio.Text.Trim() != "")
                  {
                      dane.film_studio = Studio.Text;
                  }
                  dane.title = Title.Text;
                  dane.title_orginal = NTitle.Text;
                  dane.orginal_language = Language.Text;
                  dane.duration = TimeSpan.Parse(Duration.Text);
                if(Age.SelectedItem!=null)
                {
                    dane.age_restriction = int.Parse(((ComboBoxItem)Age.SelectedItem).Content.ToString());
                }
                if(Publisher.Text.Trim()!="")
                {
                    dane.publisher = Publisher.Text;
                }
                if(Rating.Text.Trim()!="")
                {
                    dane.rating = int.Parse(Rating.Text);
                }
                if (Month.Text.Trim() != "" && Day.Text.Trim() != "" && Year.Text.Trim() != "")
                {
                   dane.release_date = System.DateTime.Parse(Month.Text+"/" + Day.Text+"/" + Year.Text);
                }
                MainWindow.AddFilm(dane);
              }
              
        
        }

        private void Rating_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void Month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
  
        }

        private void Day_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

     

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void Year_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void Duration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

    }
}
