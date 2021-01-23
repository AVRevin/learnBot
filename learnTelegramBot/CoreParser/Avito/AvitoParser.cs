using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnTelegramBot.CoreParser.Avito
{
    class AvitoParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var pricelist = new List<string>();
            var result = new List<string>();

            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("link-link-39EVK link-design-default-2sPEv title-root-395AQ iva-item-title-1Rmmj title-list-1IIB_ title-root_maxHeight-3obWc"));
            var priceitems = document.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Contains("price-text-1HrJ_ text-text-1PdBw text-size-s-1PUdo"));

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            foreach (var item in priceitems)
            {
                pricelist.Add(item.TextContent);
            }

            var templist = list.ToArray();
            var temppricelist = pricelist.ToArray();
            var Length = templist.Length;

            Console.WriteLine(templist[0] + temppricelist[0]); 

            return list.ToArray();
        }
    }
}
