namespace ConsoleApp2;

public class FileNotFindException : Exception
{
    public FileNotFindException(string message) : base(message)
    {
    }

}