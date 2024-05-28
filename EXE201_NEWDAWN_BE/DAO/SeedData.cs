using System.Text.Json;
using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO;

public class SeedData
{
    public static async Task SeedAccount(DataContext context)
    {
        if (await context.PaymentTransaction.AnyAsync() && await context.PaymentTransactionDetail.AnyAsync())
        {
            return;
        }

        var transactionData = await File.ReadAllTextAsync("transaction.json");
        var detailDate = await File.ReadAllTextAsync("detail.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var payments = JsonSerializer.Deserialize<List<PaymentTransaction>>(transactionData);
        var details = JsonSerializer.Deserialize<List<PaymentTransactionDetail>>(detailDate);

        foreach (var payment in payments)
        {
            context.PaymentTransaction.Add(payment);
        }

        foreach (var detail in details)
        {
            context.PaymentTransactionDetail.Add(detail);
        }

        await context.SaveChangesAsync();
    }
}