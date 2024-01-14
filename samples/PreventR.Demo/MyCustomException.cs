public class MyCustomException: Exception
{
    public MyCustomException(string parameterName, string message): base(message)
    {
        ParameterName = parameterName;
    }

    public string ParameterName { get; }
}
