namespace Nobby.ChatBot.Models.Common
{
    public class CommonModel
    {
        public CommonModel()
        {
            Id = "";
            Session = new Session();
            Request = new Request();
            Response = new Response();
        }

        public string Id { get; set; }
        internal Session Session { get; set; }
        internal Request Request { get; set; }
        internal Response Response { get; set; }
    }
}