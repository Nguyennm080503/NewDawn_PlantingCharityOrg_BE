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
        if (await context.UserInformation.AnyAsync())
        {
            return;
        }

        var accountData = await File.ReadAllTextAsync("AccountSeedData.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var accounts = JsonSerializer.Deserialize<List<UserInformation>>(accountData);

        foreach (var account in accounts)
        {
            using var hmac = new HMACSHA512();

            account.Username = account.Username.ToLower();
            account.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("pá"));
            account.PasswordSalt = hmac.Key;

            context.UserInformation.Add(account);
        }

        await context.SaveChangesAsync();
    }
}