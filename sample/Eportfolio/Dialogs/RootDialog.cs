using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading;

namespace Eportfolio.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        int count = 0;
        String username = ""; 
        public Task StartAsync(IDialogContext context)
        {
            
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            
            var message = await argument;
            bool use = false; 
            if (message.Text.Contains("doctor"))
            { await context.Forward(new DoctorDialog(), ResumeAfterNewOrderDialog, message, CancellationToken.None);
                use = true;
            }

            if (message.Text.Contains("count"))
            {
                await context.Forward(new EchoWithCountDialog(), ResumeAfterNewOrderDialog, message, CancellationToken.None);
                use = true;
            }
            if (!use)
            context.Wait(MessageReceivedAsync);
        }

        private async Task ResumeAfterNewOrderDialog(IDialogContext context, IAwaitable<object> result)
        {
           

            await context.PostAsync("how can i help you ?");
            context.Wait(MessageReceivedAsync);
            
        }
        private async Task ResumeAfterNewOrderDialog(IDialogContext context, IAwaitable<string> result)
        {
            var res = await result;
            if (res.Contains("Name: "))
                username = res.Split(' ')[1];

            await context.PostAsync("how can i help you ?");
            context.Wait(MessageReceivedAsync);
        }


    }
}