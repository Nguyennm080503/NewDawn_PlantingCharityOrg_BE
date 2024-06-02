using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO;

public class SeedData
{
    public static async Task SeedAccount(DataContext context)
    {
        //if (await context.PaymentTransactionDetail.AnyAsync())
        //{
        //    return;
        //}

        //var transactionData = await File.ReadAllTextAsync("transaction.json");
        //var detailData = await File.ReadAllTextAsync("detail.json");
        //var userData = await File.ReadAllTextAsync("AccountSeedData.json");

        //var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        //var payments = JsonSerializer.Deserialize<List<PaymentTransaction>>(transactionData);
        //var details = JsonSerializer.Deserialize<List<PaymentTransactionDetail>>(detailData);
        //var users = JsonSerializer.Deserialize<List<UserInformation>>(userData);

        ////foreach (var user in users)
        ////{
        ////    using var hmac = new HMACSHA512();

        ////    user.Username = user.Username.ToLower();
        ////    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123456"));
        ////    user.PasswordSalt = hmac.Key;
        ////    context.UserInformation.Add(user);
        ////} 

        ////foreach (var payment in payments)
        ////{
        ////    context.PaymentTransaction.Add(payment);
        ////}

        //foreach (var detail in details)
        //{
        //    context.PaymentTransactionDetail.Add(detail);
        //}

        //await context.SaveChangesAsync();
    }
}