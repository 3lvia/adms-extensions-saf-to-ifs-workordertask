namespace MaintenanceOrderReader.MessageHandlers
{
    public interface IMessageHandler
    {
        void HandleMessage(string messageText);
    }
}
