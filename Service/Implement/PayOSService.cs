using DTOS;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Types;
using Service.Interface;
using System;

namespace Service.Implement
{
    public class PayOSService : IPayOSService
    {
        public async Task<string> CreatePaymentLink(int quantitys, string urlCancel, string urlReturn)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var client = config["PayOS:ClientID"];
            var apiKey = config["PayOS:APIKey"];
            var checkSumKey = config["PayOS:CheckSumKey"];

            PayOS payOS = new PayOS(client, apiKey, checkSumKey);

            ItemData item = new ItemData("Cây", quantitys, quantitys * 150000);
            List<ItemData> items = new List<ItemData>();
            items.Add(item);

            Random rand = new Random();
            string orderID = "";
            PaymentLinkInformation paymentLinkInformation = null;

            do
            {
                orderID = "";
                for (int i = 0; i < 6; i++)
                {
                    orderID += rand.Next(0, 10);
                }

                paymentLinkInformation = await payOS.getPaymentLinkInformation(int.Parse(orderID));
            } while (paymentLinkInformation != null);

            PaymentData paymentData = new PaymentData(int.Parse(orderID), quantitys * 150000, "Thanh toan don hang",
            items, urlCancel, urlReturn);

            CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
            return createPayment.checkoutUrl;
        }
    }
}
