﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;


namespace MyScapperProgects
{
    class GetFilms
    {
        HtmlAgilityPack.HtmlWeb htmlwebm = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument docm = new HtmlDocument();
        WebClient web = new WebClient();
        
        public void Scrap()
        {
            List<string> str = new List<string>();
            //string str=web.DownloadString("http://www.imdb.com/search/title?at=0&languages=fa%7C1&sort=num_votes&title_type=feature");
            //&start=51
            docm = htmlwebm.Load
                ("http://www.imdb.com/search/title?at=0&languages=fa%7C1&sort=num_votes&title_type=feature");
            //div/following-sibling::p[preceding::div]     @"//span[@class=""wlb_wrapper""]//following::span[@class=""wlb_wrapper""]")

            foreach (var itemm in docm.DocumentNode.SelectNodes(@"//span[@class=""wlb_wrapper""]"))
            {
         
                str.Add("http://www.imdb.com/title/"+itemm.Attributes[1].Value);
            }
            //foreach (var itemm in docm.DocumentNode.SelectNodes(@"//span[@class=""wlb_wrapper""]"))
            //{
            //    str.Add(itemm.OuterHtml.ToString());
            //}
            int x;
        }
    }
}
