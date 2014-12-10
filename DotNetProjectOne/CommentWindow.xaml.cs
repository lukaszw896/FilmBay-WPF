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
    /// Interaction logic for CommentWindow.xaml
    /// </summary>
    public partial class CommentWindow : Window
    {
        user_table Myself = StartWindow.Myself;
        int filmid = FilmPage.filmid;
        FilmPage filmPage;

        /*Constructor*/
        public CommentWindow(FilmPage fp)
        {
            InitializeComponent();
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
            filmPage = fp;

        }
        /*event closing popup window with comments*/
        private void CloseCommentPopup_Click(object sender, RoutedEventArgs e)
        {
            filmPage.IsEnabled = true;
            this.Close();
        }

        /* dragging window event handler */
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /*submit comment event handler*/
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            StartWindow.pages.filmPage.IsEnabled = true;
            comment_table ct = new comment_table();
            ct.id_film = filmid;
            ct.id_user = Myself.id_user;
            bool Alreadycommented = (con.comment_tables.AsParallel().Where(s => s.id_film == filmid && s.id_user == Myself.id_user).Count()) > 0;
            if (Alreadycommented == true)
            {
                ct.comment = CommentBox.Text;
                DBAccess.UpdateComment(ct);
                con.Dispose();
            }
            else
            {
                ct.comment = CommentBox.Text;
                DBAccess.AddComment(ct);

                con.Dispose();
            }
            con.Dispose();
            StartWindow.SetPage(new FilmPage());
          //  filmPage.IsEnabled = true;
            this.Close();
        }

        /* invoking submitButton event with enter click -- posting comment */
        private void CommentsWindow_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                submitButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

        }
    }
}
