using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nobby.ChatBot.Models.Common;

namespace Nobby.ChatBot.Handlers
{
    public static class YesIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Event = "EVENTNAME";

            return commonModel;
        }
    }
}