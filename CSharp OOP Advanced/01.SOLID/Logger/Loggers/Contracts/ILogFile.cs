namespace Logger.Loggers.Contracts
{
    public interface ILogFile
    {
        string Size { get; }

        void Write(string message);
    }
}
