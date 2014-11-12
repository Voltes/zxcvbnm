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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImdbFilmPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

         



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int StrLen = 0;
            IMDB imdb = new IMDB("http://www.imdb.com/title/tt0816692");
            
            int val = imdb.Cast.Count;

            for (int i = 0; i < imdb.Cast.Count; i++)
            {
                listbox1.Items.Add(imdb.Cast[i].ToString());
                listbox2.Items.Add(imdb.MyCast[i].ToString());
            }

        }
    }
}
