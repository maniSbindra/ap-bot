namespace MultiDialogsBot.Dialogs
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using System.Web.Script.Serialization;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [Serializable]
    public class SelectShadeDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {

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
            foreach (Product product in products)
            {
                await context.PostAsync(product.id);
            }

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
            
           // context.Fail(new NotImplementedException("Flights Dialog is not implemented and is instead being used to show context.Fail"));
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {

            var message = await argument;
            await context.PostAsync("You said: " + message.Text);
            context.Wait(MessageReceivedAsync);


        }
    }
}