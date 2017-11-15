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
    public class EchoWithCountDialog : IDialog<object>
    {
        protected int count = 1; 
        public async Task StartAsync(IDialogContext context)
        {
            
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context,IAwaitable<IMessageActivity> argument)
        {
            var massage = await argument;

            if(massage.Text=="reset")
            {
                PromptDialog.Confirm(context, AfterResetSync, "Are you sure", "Didn´t get that!", promptStyle: PromptStyle.None);
            }
            else
            {
                await context.PostAsync($"{this.count++}:You said {massage.Text}");
                context.Wait(MessageReceivedAsync);
            }

           
           
        }
        public async Task AfterResetSync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if(confirm)
            {
                this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}