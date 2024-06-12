using DTOS;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Errors;
using Net.payOS.Types;
using Net.payOS.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Service.Interface;
using System.Text.Json;

namespace Service.Implement
{
    public class PayOSService : IPayOSService
    {
        public async Task<string> CreatePaymentLink(int quantity, string urlCancel, string urlReturn)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var client = config["PayOS:ClientID"];
            var apiKey = config["PayOS:APIKey"];
            var checkSumKey = config["PayOS:CheckSumKey"];

            PayOS payOS = new PayOS(client, apiKey, checkSumKey);

            ItemData item = new ItemData("Cây", quantity, quantity * 150000);
            List<ItemData> items = new List<ItemData>();
            items.Add(item);

            Random rand = new Random();
            string orderID = "";
            PaymentLinkInformation paymentLinkInformation = null;
            try
            {
                do
                {
                    orderID = "";
                    for (int i = 0; i < 6; i++)
                    {
                        orderID += rand.Next(0, 10);
                    }

                    paymentLinkInformation = await payOS.getPaymentLinkInformation(int.Parse(orderID));
                } while (paymentLinkInformation != null);
                return "";
            }
            catch (Exception ex) {
                PaymentData paymentData = new PaymentData(int.Parse(orderID), quantity * 150000, "Thanh toan don hang",
            items, urlCancel, urlReturn);

                CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
                return createPayment.checkoutUrl;
            }
        }

        public async Task<TransactionReturn> HandleCodeAfterPaymentQR(int code)
        {
            try
            {
                IConfigurationRoot config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();

                var client = config["PayOS:ClientID"];
                var apiKey = config["PayOS:APIKey"];
                var checkSumKey = config["PayOS:CheckSumKey"];

                PayOS payOS = new PayOS(client, apiKey, checkSumKey);
                PaymentLinkInformation paymentLinkInformation = await getPaymentLinkInformation(code);
                var inf = paymentLinkInformation.transactions.FirstOrDefault();
                var bankAccounts = GetBankAccount();
                var bank = bankAccounts.Result.FirstOrDefault(x => x.bin == inf.counterAccountBankId);
                var transaction = new TransactionReturn()
                {
                    AccountName = inf.counterAccountName,
                    AccountNumber = inf.counterAccountNumber,
                    Amount = inf.amount,
                    BankCode = bank.code,
                    BankName = bank.shortName,
                    Reference = inf.reference,
                    Description = inf.description,
                    TransactionDate = DateTime.Parse(inf.transactionDateTime)
                };
                return transaction;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<BankAccount>> GetBankAccount()
        {
            var bankData = await File.ReadAllTextAsync("BankAccount.json");

            var banks = System.Text.Json.JsonSerializer.Deserialize<List<BankAccount>>(bankData);
            return banks;
        }

        public async Task<PaymentLinkInformation> getPaymentLinkInformation(long orderId)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();

            var client = config["PayOS:ClientID"];
            var apiKey = config["PayOS:APIKey"];
            var checkSumKey = config["PayOS:CheckSumKey"];

            string url = "https://api-merchant.payos.vn/v2/payment-requests/" + orderId;
            HttpClient httpClient = new HttpClient();
            JObject responseBodyJson = JObject.Parse(await (await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
            {
                { "x-client-id", client },
                { "x-api-key", apiKey }
            }
            })).Content.ReadAsStringAsync());
            string code = responseBodyJson["code"]?.ToString();
            string desc = responseBodyJson["desc"]?.ToString();
            string data = responseBodyJson["data"]?.ToString();
            if (code == null)
            {
                throw new PayOSError("20", "Internal Server Error.");
            }

            if (code == "00" && data != null)
            {
                PaymentLinkInformation response = JsonConvert.DeserializeObject<PaymentLinkInformation>(data);
                if (response == null)
                {
                    throw new InvalidOperationException("Error deserializing JSON response: Deserialized object is null.");
                }

                return response;
            }

            throw new PayOSError(code, desc);
        }


    }
}
