public class Program
{
  public static async Task Main()
  {
    List<Account> accounts = await GetAccountAsync();

    System.Console.WriteLine("\n=== Active Account ===");
    var activeAccounts = accounts.Where(a => a.IsActive).ToList();
    foreach (var a in activeAccounts)
    {
      System.Console.WriteLine($"{a.AccountNumber} - {a.Name} - Rp{a.Balance:N0}");
    }

    System.Console.WriteLine("\n=== Richest Account ===");
    var sorted = activeAccounts.OrderByDescending(a => a.Balance);
    foreach (var a in sorted)
    {
      System.Console.WriteLine($"{a.AccountNumber} - {a.Name} - Rp{a.Balance:N0}");
    }

    System.Console.WriteLine("\n=== Account Owner ===");
    foreach (var name in accounts.Select(a => a.Name))
    {
      System.Console.WriteLine(name);
    }

    decimal total = accounts.Sum(a => a.Balance);
    System.Console.WriteLine("\n=== Total Balance ===");
    System.Console.WriteLine($"Total sald: Rp{total:N0}");

    System.Console.WriteLine("\n=== Find ACC005 ===");
    var found = await FindAccountAsync(accounts, "ACC005");
    if (found == null)
    {
      System.Console.WriteLine("Account not found!");
    } else
    {
      System.Console.WriteLine($"{found.AccountNumber} - {found.Name} - Rp{found.Balance}");
    }
  }

  private static async Task<List<Account>> GetAccountAsync()
  {
    await Task.Delay(500);
    return new List<Account>
    {
      new CurrentAccount("ACC001", "Andi", 500000, true),
      new CurrentAccount("ACC002", "Budi", 750000, true),
      new CurrentAccount("ACC003", "DIna", 250000, false),
      new CurrentAccount("ACC004", "Satrio", 1000000000, true),
    };
  }

  private static async Task<Account?> FindAccountAsync(List<Account> accounts, string accountNumber)
  {
    await Task.Delay(500);
    return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
  }
}