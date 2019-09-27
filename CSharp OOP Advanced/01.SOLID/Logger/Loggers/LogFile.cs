namespace Logger.Loggers
{
    using Contracts;
    public class LogFile : ILogFile
    {
        public string Size { get; private set; }

        public void Write(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if ((message[i] >= 'a' && message[i] <= 'z') || (message[i] >= 'A' && message[i] <= 'Z'))
                {
                    this.Size += message[i];
                }
            }

            // this.Size += message.Where(char.IsLetter).Sum(ch => ch);
        }
    }
}
