    public class Hacker
    {       
        public string username = "securityGod82";   // must be private
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get => this.password;
            set => this.password = value;           // setter must be private
    }

        private int Id { get; set; }               // getter must be public
                                                  
        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {
        }
    }


