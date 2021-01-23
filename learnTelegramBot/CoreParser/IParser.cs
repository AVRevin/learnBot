using AngleSharp.Html.Dom;

namespace learnTelegramBot.CoreParser
{
    interface IParser<T> where T:class
    {
        T Parse(IHtmlDocument document);
    }
}
