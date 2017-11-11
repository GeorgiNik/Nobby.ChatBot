namespace Nobby.ChatBot.Models.Common
{
    public class Response
    {
        public string Text { get; set; }
        public string Ssml { get; set; }
        public string Prompt { get; set; }
        public string Event { get; set; }
        public Card Card { get; set; }
    }
}