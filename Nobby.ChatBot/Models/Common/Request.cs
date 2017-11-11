namespace Nobby.ChatBot.Models.Common
{
    using System.Collections.Generic;

    public class Request
    {
        public string Id { get; set; }
        public string Intent { get; set; }
        public string State { get; set; }
        public string Channel { get; set; }
        public List<KeyValuePair<string,string>> Parameters { get; set; }
    }
}