namespace BulkChangeResponseReader.MessageHandlers
{
    public interface IMessageHandler
    {
        void HandleMessage(string messageText);
    }
}
