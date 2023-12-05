namespace PersonalExceptions;

public class FileNotFindException : Exception
{
    public FileNotFindException(string message) : base(message)
    {
    }

}