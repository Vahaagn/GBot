using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Cognitive.LUIS;

namespace GBot
{
    public class IntentHandlers
    {
        [IntentHandler(0.5, Name = Intents.OpenSite)]
        public static void OpenSite(LuisResult result, object context)
            => new OpenSiteService().Handle(result);

        [IntentHandler(0.7, Name = Intents.None)]
        public static void None(LuisResult result, object context)
        {
        }
    }
}