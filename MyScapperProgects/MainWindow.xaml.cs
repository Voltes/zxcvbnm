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
using HtmlAgilityPack;
using System.Web;
using System.Net;

namespace MyScapperProgects
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
            //WebClient web = new WebClient();
            //string str = web.DownloadString("http://www.imdb.com/movies-in-theaters/");
          

            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument Doc = new HtmlDocument();

            FilmRelease MyFilm = new FilmRelease();
            List<FilmRelease> MyFilmList = new List<FilmRelease>();
            
                       
            Doc = htmlweb.Load("http://www.imdb.com/movies-in-theaters/");
            //Doc = htmlweb.Load("http://www.imdb.com/movies-coming-soon/");
            textbox1.Clear();
      
            foreach (var item in Doc.DocumentNode.SelectNodes(@"//td[@class=""overview-top""]"))
            {
                HtmlDocument doc1 = new HtmlDocument();
                doc1.LoadHtml(item.InnerHtml);

                foreach (var item1 in doc1.DocumentNode.SelectNodes(@"//h4[@itemprop=""name""]"))
                {
                    HtmlDocument doc2 = new HtmlDocument();
                    doc2.LoadHtml(item1.InnerHtml);
                    foreach (var item2 in doc2.DocumentNode.SelectNodes(@"//a[@href]"))
                    {
                        textbox1.Text += item2.InnerHtml.Trim()+"\n";
                        string str = item2.Attributes[0].Value;
                        MyFilm.FilmName.Add(item2.InnerHtml.Trim(), item2.Attributes[0].Value);
                        break;
                    }
                    if (doc2.DocumentNode.SelectNodes(@"//img[@title]") != null)
                    {
                        foreach (var item2 in doc2.DocumentNode.SelectNodes(@"//img[@title]"))
                        {
                            //string str = item2.Attributes[0].Value;
                            MyFilm.Certification = item2.Attributes[0].Value;
                            break;
                        }
                    }
                    if (doc1.DocumentNode.SelectNodes(@"//time[@itemprop]") != null)
                    {
                        foreach (var item2 in doc1.DocumentNode.SelectNodes(@"//time[@itemprop]"))
                        {
                            //string str = item2.InnerHtml;
                            MyFilm.FilmMinutes =item2.InnerHtml;
                            break;
                        }
                    }
           
                    if (doc1.DocumentNode.SelectNodes(@"//span[@itemprop=""genre""]") != null) 
                    {
                        foreach (var item2 in doc1.DocumentNode.SelectNodes(@"//span[@itemprop=""genre""]"))
                        {
                            //string str = item2.InnerHtml;
                            MyFilm.Genre.Add(item2.InnerHtml);
                        }
                    }

                    if (doc1.DocumentNode.SelectNodes(@"//div[@itemprop=""description""]") != null)
                    {
                        foreach (var item2 in doc1.DocumentNode.SelectNodes(@"//div[@itemprop=""description""]"))
                        {
                            //inner text b in khater k age inner html bashe va name shakhsi ham bashe 
                            //b sorate yek tage a html zaher mishe 
                            //ama ba innertext mesle safhe yaye html browser b sorate text miyad na html
                            //string str = item2.InnerText.Trim();
                            MyFilm.Description = item2.InnerText.Trim();
                        }
                    }
                    if (doc1.DocumentNode.SelectNodes(@"//span[@itemprop=""director""]") != null)    
                    {
                        foreach (var item2 in doc1.DocumentNode.SelectNodes(@"//span[@itemprop=""director""]"))
                        {
                            //string str = item2.InnerHtml.Trim();
                            HtmlDocument doc3 = new HtmlDocument();
                            doc3.LoadHtml(item2.InnerHtml);
                            //to do
                            //momkene chanta kargardan bashe... bayad b sorate list piyade sazi shavad...
                            foreach (var item3 in doc3.DocumentNode.SelectNodes(@"//a[@href]"))
                            {
                                //string str = item3.InnerHtml.Trim();
                                //string str1 = item3.Attributes[0].Value;
                                MyFilm.FilmDirector.Add(item3.InnerHtml.Trim(), item3.Attributes[0].Value);
                            }

                        }
                    }
                    if (doc1.DocumentNode.SelectNodes(@"//span[@itemprop=""actors""]") != null) 
                    {
                        foreach (var item2 in doc1.DocumentNode.SelectNodes(@"//span[@itemprop=""actors""]"))
                        {
                            HtmlDocument doc3 = new HtmlDocument();
                            doc3.LoadHtml(item2.InnerHtml);
                           
                            foreach (var item3 in doc3.DocumentNode.SelectNodes(@"//a[@href]"))
                            {
                                //string str = item3.InnerHtml.Trim();
                                //string str1 = item3.Attributes[0].Value;
                                MyFilm.FilmStars.Add(item3.InnerHtml.Trim(), item3.Attributes[0].Value);
                    
                            }
                          
                        }
                    }


                }
                MyFilmList.Add(MyFilm);
                MyFilm = new FilmRelease();
          
            }
            MessageBox.Show("here WE go");
          

            

        }
    }
}
