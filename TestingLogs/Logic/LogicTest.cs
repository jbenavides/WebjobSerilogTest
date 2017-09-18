namespace TestingLogs.Logic
{
    public interface ILogicTest
    {
        string GetMessage(string name);
    }
    public class LogicTest : ILogicTest
    {
        public string GetMessage(string name)
        {
            return $"Hello {name}";
        }
    }
}
