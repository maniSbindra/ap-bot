namespace MultiDialogsBot.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Connector;
    using Newtonsoft.Json;

    [Serializable]
    public class FindProductDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            // await context.PostAsync("Welcome, Lets help you find what youre looking for. Please type in your que//ry");
            // context.Wait(MessageReceivedAsync);
            //context.se
            //PromptDialog.Text(context, resume , "Welcome, Lets help you find what youre looking for. Please type in your query", null, 3);
            //context.Wait(MessageReceivedAsync);
            string valueByUser = "";
            //await context.PostAsync("Welcome, Lets help you find what youre looking for. Please type in your query");
             PromptDialog.Text(context, FreeFormText , "Welcome, Lets help you find what youre looking for. Please type in your query");
            
        }

        private async Task FreeFormText(IDialogContext context, IAwaitable<string> argument)
        {

            var message = await argument;

            string jsonProducts = @"
    [
        {
            'id': '1',
            'productCategory': ['external'],
            'productCode': 'asdfasd23e',
            'productName': 'External Paint',
            'fastFacts': [
                'fact1',
                'fact2',
                'fact3',
                'fact4'
            ],
            'applications': [
                'application1',
                'application2',
                'application3',
                'application4'
            ],
            'features': [
                'feature1',
                'feature2',
                'feature3',
                'feature4'
            ],
            'benefits': [
                'benefit1',
                'benefit2',
                'benefit3',
                'benefits4'
            ]
    },
{
            'id': '1',
            'productCategory': ['external'],
            'productCode': 'asdfasd23e',
            'productName': 'External Paint',
            'fastFacts': [
                'fact1',
                'fact2',
                'fact3',
                'fact4'
            ],
            'applications': [
                'application1',
                'application2',
                'application3',
                'application4'
            ],
            'features': [
                'feature1',
                'feature2',
                'feature3',
                'feature4'
            ],
            'benefits': [
                'benefit1',
                'benefit2',
                'benefit3',
                'benefits4'
            ]
    }
    ]
";


            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);


            var resultMessage = context.MakeMessage();
            resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            resultMessage.Attachments = new List<Attachment>();

            foreach (Product product in products)
            {
                HeroCard heroCard = new HeroCard()
                {
                    Title = product.productName,
                    Subtitle = product.productName,
                    Images = new List<CardImage>()
                        {
                            new CardImage() { Url = $"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTXN8r4QKhfJ4fVI41rODPlk8E1axdQl5zRgFsj8ewfZy28xZA5KImuKCYK" }
                        },
                    Buttons = new List<CardAction>()
                        {
                            new CardAction()
                            {
                                Title = "More details",
                                Type = ActionTypes.OpenUrl,
                                Value = $"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTXN8r4QKhfJ4fVI41rODPlk8E1axdQl5zRgFsj8ewfZy28xZA5KImuKCYK"
                            }
                        }
                };

                resultMessage.Attachments.Add(heroCard.ToAttachment());
            }

            await context.PostAsync(resultMessage);
            context.Wait(MessageReceivedAsync);

        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
      {
            
            var message = await argument;
           // await context.PostAsync("You said: " + message.Text);
         //context.Wait(MessageReceivedAsync);
            
            
      }



    }
}