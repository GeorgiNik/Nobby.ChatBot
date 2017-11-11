using ApiAiSDK.Model;
using System.Collections.Generic;
using System.Linq;
using Nobby.ChatBot.Models.Common;

namespace Nobby.ChatBot.Helpers
{
    public class CommonModelMapper
    {
        internal static CommonModel ApiAiToCommonModel(AIResponse aiResponse)
        {
            var commonModel = new CommonModel
            {
                Id = aiResponse.Id,
                Session =
                {
                    Id = aiResponse.SessionId
                },
                Request =
                {
                    Intent = aiResponse.Result.Metadata.IntentName,
                    State = aiResponse.Result.ActionIncomplete ? "IN_PROGRESS" : "COMPLETED",
                    Channel = aiResponse.Result.Source,
                    Parameters = aiResponse.Result.Parameters.ToList().ConvertAll(p => new KeyValuePair<string, string>(p.Key, p.Value.ToString()))
                }
            };

            return commonModel;
        }

        internal static dynamic CommonModelToApiAi(CommonModel commonModel)
        {
            if (string.IsNullOrWhiteSpace(commonModel.Response.Event))
            {
                return new
                {
                    speech = (string.IsNullOrWhiteSpace(commonModel.Response.Ssml) || commonModel.Request.Channel == "agent") ? commonModel.Response.Text : "<speak>" + commonModel.Response.Ssml + "</speak>",
                    displayText = commonModel.Response.Text,
                    data = new
                    {
                        slack = new
                        {
                            text = commonModel.Response.Text
                        },
                        google = new
                        {
                            expectUserResponse = !commonModel.Session.EndSession
                        }
                    },
                    source = "Some text"
                };
            }
            
            return new
            {
                followupEvent = new
                {
                    name = commonModel.Response.Event
                }
            };
        }
    }
}