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
    public class NewOrderDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Whats ur Name ? ");
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context,IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
          
           context.Done("Name: "+message.Text);
          
            
        }
    }
}