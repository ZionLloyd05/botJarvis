// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using BookAssistantBot.API;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookAssistanceBot.Bots
{
    public class SearchBot : ActivityHandler
    {
        private readonly GoodReadsAPIWrapper wrapper = new GoodReadsAPIWrapper();

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var input = turnContext.Activity.Text;
            var inputResponse = await wrapper.GetSearchReponse(input);
            var attachment = MessageFactory.Attachment(new List<Attachment>());

            if (inputResponse != null)
            {
                var message = $"{input} found {inputResponse.Search.TotalResults}. Top 3 results";

                var items = inputResponse.Search.Results.WorkItems.Take(3);

                var heroCards = items.Select(i => new HeroCard
                {
                    Images = new[] { new CardImage{ Url = i.BookItem.ImageUrl } },
                    Title = i.BookItem.Title,
                    Subtitle = i.BookItem.Author.Name
                });

                attachment.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                foreach (var item in heroCards)
                {
                    attachment.Attachments.Add(item.ToAttachment());
                }

                await turnContext.SendActivityAsync(message, cancellationToken: cancellationToken);
                await turnContext.SendActivityAsync(attachment, cancellationToken);
            }

            await AskSearch(turnContext, cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello, I'm Jarvis, your Book Assistance";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                    await AskSearch(turnContext, cancellationToken);
                }
            }
        }

        private async Task AskSearch(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var message = MessageFactory.Text("What book would you like to check out ?");
            await turnContext.SendActivityAsync(message, cancellationToken);
        }
    }
}
