namespace Newsfeed.Application.Wrappers;
public class ServiceResponse<TData>
{
    public ServiceResponse(TData data, string message = "", bool succeeded = true)
    {
        Succeeded = succeeded;
        UserMessage = message;
        Data = data;
    }

    public ServiceResponse(string message, bool succeeded)
    {
        Succeeded = succeeded;
        UserMessage = message;
    }

    public bool Succeeded { get; set; }

    public string UserMessage { get; set; }

    public string SystemMessage { get; set; }

    public List<string> Errors { get; set; }

    public TData Data { get; set; }
}
