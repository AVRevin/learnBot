
namespace learnTelegramBot.CoreParser.Avito
{


    class AvitoSettings : IParserSettings
    {
        public AvitoSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://www.avito.ru/voronezh/tovary_dlya_kompyutera/monitory-ASgBAgICAUTGB4Bo?cd=1&q=%D0%BC%D0%BE%D0%BD%D0%B8%D1%82%D0%BE%D1%80&s=104";
        public string  Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
