public class Hacker
{
    public string username = "securityGod82";
    private string password = "mySuperSecretPassw0rd";

    public string Password
    {
        get => this.password;
        set => this.password = value;
    }

    private int Id { get; set; }   // should find

    public double BankAccountBalance { get; private set; } // should find

    public void DownloadAllBankAccountsInTheWorld()
    {
    }
}

