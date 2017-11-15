using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Services.Description;
using Microsoft.Bot.Connector;

namespace Eportfolio.Dialogs
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context,IAwaitable<IMessageActivity> argument)
        {
            var massage = await argument;
            await context.PostAsync("Yout said:" + massage.Text);
            context.Wait(MessageReceivedAsync);
        }
    }
}