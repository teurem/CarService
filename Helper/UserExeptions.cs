namespace digitization.Helper;

public class SQLException : Exception
{
    public SQLException()
    {
    }

    public SQLException(string message)
        : base(message)
    {
    }

    public SQLException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
public class NullPointException : Exception
{
    public NullPointException()
    {
    }

    public NullPointException(string message)
        : base(message)
    {
    }

    public NullPointException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
public class InvalidTypeDateException : Exception
{
    public InvalidTypeDateException()
    {
    }

    public InvalidTypeDateException(string message)
        : base(message)
    {
    }

    public InvalidTypeDateException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
