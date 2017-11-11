using Nobby.ChatBot.Models.Common;

namespace Nobby.ChatBot.Handlers
{
    public static class WelcomeIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Text = "Hi there, would you like to book a table?";
            commonModel.Response.Prompt = "Would you like to book a table? Yes or no?";
            commonModel.Session.EndSession = false;

            return commonModel;
        }
    }
}