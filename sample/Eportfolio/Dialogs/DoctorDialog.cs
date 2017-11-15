using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Services.Description;
using Microsoft.Bot.Connector;
using System.Threading;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Eportfolio.Dialogs
{
    [Serializable]
    public class DoctorDialog : IDialog<object>
    {
        int count = 0; 
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hello I am your personal mental Support ");
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            String question = "Can you tell me about your problems ";
            if (count != 0) {
                if (message.Text.Contains("thank"))
                { context.Done(message.Text); }





                if (message.Text.Contains("suicide") || (message.Text.Contains("end") && message.Text.Contains("life")))
                { question = "If you are serious please go to a real doctor or call 0800/3330333"; }

                else
                {
                    
                    if (message.Text.Contains("yes"))
                    {
                        question = "I know this must be hard. Can You tell me something else about yourself ? ";
                    }
                    else {

                              String lastword = message.Text.Split(' ').Last();
                        Random random = new Random();

                        switch (random.Next(4))
                        {
                            case 0:
                                question = $"Could you tell me more about {lastword}";
                                break;
                            case 1:
                                question = $"Makes {lastword} you sad ?";
                                break;
                            case 2:
                                question = $"What du you think about {lastword}";
                                break;
                            case 3:
                                question = $"{lastword} sounds intresting. What do you feel about {lastword}";
                                break;
                            case 4:
                                question = $"let {lastword} you sleep at night?";
                                break;

                        } }
                    

                }
               
                

            }
           
            count++;
            if (!message.Text.Contains("thank"))
            {
                await context.PostAsync(question);
                context.Wait(MessageReceivedAsync);
            }
               

           
        }

    }
}