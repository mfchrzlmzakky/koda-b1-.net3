public abstract class Account
{
  public string AccountNumber {get; set;}
  public string Name {get; set;}
  public decimal Balance {get; set;}
  public bool IsActive {get; set;}

  protected Account(string accountNumber, string name, decimal balance, bool isActive)
  {
    AccountNumber = accountNumber;
    Name = name;
    Balance = balance;
    IsActive = isActive;
  }
}