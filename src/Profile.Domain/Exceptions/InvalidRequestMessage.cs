namespace Profile.Domain.Exceptions;

public class InvalidRequestMessage
{
    public InvalidRequestMessage(string message)
    {
        Message = message;
    }

    public string Message { get; }
}