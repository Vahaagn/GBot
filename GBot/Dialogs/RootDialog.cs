using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Cognitive.LUIS;

namespace GBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        const string modelId = "b484cbd6-1f69-482e-a0e6-bd8c7181ee11";
        const string subscriptionKey = "3fc3094ef2e84cffb7f788e8a6b2efa7";
        const string domain = "https://westeurope.api.cognitive.microsoft.com/luis/v2.0/apps";

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var client = new LuisClient(modelId, subscriptionKey, domain);

            using (var router = IntentRouter.Setup<IntentHandlers>(client))
            {
                var handled = await router.Route(activity.Text, this);
            }

            context.Wait(MessageReceivedAsync);
        }
    }
}