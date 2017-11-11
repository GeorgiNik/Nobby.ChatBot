using Nobby.ChatBot.Models.Common;

namespace Nobby.ChatBot.Handlers
{
    public class HelpIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Text = "Hola and welcome to Nobby. I can help you do something, to do so, say \"nobby\"?";
            commonModel.Response.Prompt = "If you want to do something, say, \"nobby\".";

            commonModel.Session.EndSession = false;

            return commonModel;
        }
    }
}