// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdaptiveCards;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Schema.Teams;
using Newtonsoft.Json.Linq;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class TeamsMessagingExtensionsActionBot : TeamsActivityHandler
    {
        //protected override async Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionSubmitActionAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        //{
        //    var response = new MessagingExtensionActionResponse()
        //    {
        //        Task = new TaskModuleContinueResponse()
        //        {
        //            Value = new TaskModuleTaskInfo()
        //            {
        //                Height = "large",
        //                Width = "large",
        //                Title = "Embed a video",
        //                Url = "https://online.clickview.com.au/share/embed?shareCode=7aac2301&a=false",
        //            },
        //        },
        //    };

        //    return response;


        //}

        protected override async Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionSubmitActionAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        {
            //dynamic Data = JObject.Parse(action.Data.ToString());
            var response = new MessagingExtensionActionResponse
            {
                ComposeExtension = new MessagingExtensionResult
                {
                    Type = "botMessagePreview",
                    ActivityPreview = MessageFactory.Attachment(new Attachment
                    {
                        Content = new AdaptiveCard("1.0")
                        {
                            Body = new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock() { Text = "FormField1 value was:", Size = AdaptiveTextSize.Large },
                                new AdaptiveTextBlock() { Text = "your mother" }
                            },
                            Height = AdaptiveHeight.Auto,
                            Actions = new List<AdaptiveAction>()
                            {
                                new AdaptiveSubmitAction
                                {
                                    Type = AdaptiveSubmitAction.TypeName,
                                    Title = "Submit",
                                    Data = new JObject { { "submitLocation", "messagingExtensionFetchTask" } },
                                },
                            }
                        },
                        ContentType = AdaptiveCard.ContentType
                    }) as Activity
                }
            };

            return response;
        }
    }
}
