using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RestSharp;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace azerbaycan_local_deneme
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            var count = 0;
            
            var documentUrl = web.Load("https://meclis.gov.az/?/az/content/57");
            if (documentUrl != null)
            {
                var trList = documentUrl.DocumentNode.SelectNodes("//div[@id='mod_senter_text']//div[@align='center']//tr");
                if (trList != null)
                {
                    foreach (var trItem in trList.Skip(1))
                    {
                        count++;
                        if (count<10)
                        {
                            var tdNameItem = WebUtility.HtmlDecode(trItem?.ChildNodes[0]?.InnerText?.Trim());
                            var tdBirdYear = WebUtility.HtmlDecode(trItem?.ChildNodes[1]?.InnerText?.Trim());
                            var tdEducation = WebUtility.HtmlDecode(trItem?.ChildNodes[2]?.InnerText?.Trim());
                            var tdMemberShip = WebUtility.HtmlDecode(trItem?.ChildNodes[3]?.InnerText?.Trim());
                            var tdMemberShipInfo = WebUtility.HtmlDecode(trItem?.ChildNodes[4]?.InnerText?.Trim());
                            var tdMemberShipDate = WebUtility.HtmlDecode(trItem?.ChildNodes[5]?.InnerText?.Trim());

                            //tdNameItem = WebUtility.HtmlDecode(tdNameItem);
                            //tdBirdYear = WebUtility.HtmlDecode(tdBirdYear);
                            //tdEducation = WebUtility.HtmlDecode(tdEducation);
                            //tdMemberShip = WebUtility.HtmlDecode(tdMemberShip);
                            //tdMemberShipInfo = WebUtility.HtmlDecode(tdMemberShipInfo);
                            //tdMemberShipDate = WebUtility.HtmlDecode(tdMemberShipDate);


                            List<string> list = new List<string>();

                            if (!string.IsNullOrEmpty(tdNameItem) && !string.IsNullOrWhiteSpace(tdNameItem))
                            {
                                list.Add(tdNameItem);
                            }
                            if (!string.IsNullOrEmpty(tdBirdYear) && !string.IsNullOrWhiteSpace(tdBirdYear))
                            {
                                list.Add(tdBirdYear);
                            }
                            if (!string.IsNullOrEmpty(tdEducation) && !string.IsNullOrWhiteSpace(tdEducation))
                            {
                                list.Add(tdEducation);
                            }
                            if (!string.IsNullOrEmpty(tdMemberShip) && !string.IsNullOrWhiteSpace(tdMemberShip))
                            {
                                list.Add(tdMemberShip);
                            }
                            if (!string.IsNullOrEmpty(tdMemberShipInfo) && !string.IsNullOrWhiteSpace(tdMemberShipInfo))
                            {
                                list.Add(tdMemberShipInfo);
                            }
                            if (!string.IsNullOrEmpty(tdMemberShipDate) && !string.IsNullOrWhiteSpace(tdMemberShipDate))
                            {
                                list.Add(tdMemberShipDate);
                            }

                            Console.WriteLine(list[0] + "----" + list[1] + "----" + list[2] + "----" + list[3] + "-----" + list[4] + "----" + list[5]);
                        }
                            
                        
                        
                    }
                }
            }
            Console.ReadLine();
            
           
        }




    }
}
