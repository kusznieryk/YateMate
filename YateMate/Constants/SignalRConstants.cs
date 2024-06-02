namespace YateMate.Constants;

public class SignalRConstants
{
    // ReSharper disable once InconsistentNaming
    private const int TenMB = 10 * 1024 * 1024;
    
    public const int MaximumMessageSize = TenMB;

    public const string FallbackFile = "index.html";

    public const string HubPath = "/signalRHub";

    public const string ReceiveMessage = "ReceiveMessage";

    public const string SendMessage = "SendMessageAsync";
}