using System;

namespace MaintenanceOrderReader.ActiveMQ
{
    public class UnkownMessageFormatException : Exception
    {
        public UnkownMessageFormatException()
        {
        }

        public UnkownMessageFormatException(string message)
            : base(message)
        {
        }

        public UnkownMessageFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
