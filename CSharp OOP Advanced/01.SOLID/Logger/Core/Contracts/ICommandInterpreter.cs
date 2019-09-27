namespace Logger.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);

        void AddMessage(string[] args);

        void PrintInfo();
    }
}
