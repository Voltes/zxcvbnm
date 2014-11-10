using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Windows;
using System.Text.RegularExpressions;

namespace MyScapperProgects
{
    class ListFilmInTheatersAndCommingSoon
    {

       public List<FilmRelease> Scrap()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument Doc = new HtmlDocument();

            FilmRelease MyFilm = new FilmRelease();
            List<FilmRelease> MyFilmList = new List<FilmRelease>();

            Regex regex = new Regex("^[0-9]+$");

            Doc = htmlweb.Load("http://www.imdb.com/movies-in-theaters/");
            //Doc = htmlweb.Load("http://www.imdb.com/movies-coming-soon/");
            

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
                       // textbox1.Text += item2.InnerHtml.Trim() + "\n";
                       // string str = item2.Attributes[0].Value;
                        MyFilm.FilmNameList.Add( item2.InnerHtml.Trim());
                        MyFilm.FilmAddressList.Add(item2.Attributes[0].Value);
                        MyFilm.FilmName.Add(item2.Attributes[0].Value, item2.InnerHtml.Trim());
                        break;
                    }
                    if (doc1.DocumentNode.SelectNodes(@"//img[@title]") != null)
                    {
                        foreach (var item2 in doc1.DocumentNode.SelectNodes(@"//img[@title]"))
                        {
                            MyFilm.Certification = item2.Attributes[0].Value;
                            break;
                        }
                    }
                    if (doc1.DocumentNode.SelectNodes(@"//time[@itemprop]") != null)
                    {
                        foreach (var item2 in doc1.DocumentNode.SelectNodes(@"//time[@itemprop]"))
                        {
                            MyFilm.FilmMinutes = item2.InnerHtml;
                            break;
                        }
                    }

                    if (doc1.DocumentNode.SelectNodes(@"//span[@itemprop=""genre""]") != null)
                    {
                        foreach (var item2 in doc1.DocumentNode.SelectNodes(@"//span[@itemprop=""genre""]"))
                        {
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
                            HtmlDocument doc3 = new HtmlDocument();
                            doc3.LoadHtml(item2.InnerHtml);
                            foreach (var item3 in doc3.DocumentNode.SelectNodes(@"//a[@href]"))
                            {
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
                                MyFilm.FilmStars.Add(item3.InnerHtml.Trim(), item3.Attributes[0].Value);
                            }
                        }
                    }
                }  
               MyFilm.FilmYear = Regex.Match(MyFilm.FilmNameList[0].ToString(), @"\d+").ToString();
                MyFilmList.Add(MyFilm);
                MyFilm = new FilmRelease();

            }
            return MyFilmList;
            
          

        

        }
    }
}
