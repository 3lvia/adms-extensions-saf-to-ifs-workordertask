using Apache.NMS;
using Apache.NMS.Util;
using Elvia.Telemetry;
using MaintenanceOrderReader.MessageHandlers;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MaintenanceOrderReader.ActiveMQ
{
    public class ActiveMQReader : BackgroundService
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _queueName;
        private readonly ITelemetryInsightsLogger _telemetry;
        private readonly IMessageHandler _messageHandler;

        public ActiveMQReader(IConnectionFactory connectionFactory, string queueName, IMessageHandler messageHandler, ITelemetryInsightsLogger telemetry)
        {
            _connectionFactory = connectionFactory;
            _queueName = queueName;
            _messageHandler = messageHandler;
            _telemetry = telemetry; // DI framework


            //string textMessage = "";

            //_messageHandler.HandleMessage(textMessage);

            //int x = 2;

        }

        public void HandleConnectionError(NMSException ex)
        {
            _telemetry.TrackException(ex);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Running: " + DateTime.Now.ToLongTimeString());
                Thread.Sleep(60000);

            }


            while (!stoppingToken.IsCancellationRequested && false)
            {
                try
                {
                    using IConnection connection = await _connectionFactory.CreateConnectionAsync();
                    _telemetry.TrackTrace("Connected to broker: " + _connectionFactory.BrokerUri.OriginalString);
                    using ISession session = await connection.CreateSessionAsync(AcknowledgementMode.ClientAcknowledge);
                    using IDestination destination = SessionUtil.GetDestination(session, _queueName);

                    _telemetry.TrackTrace("Connected to queue " + _queueName);
                    using IMessageConsumer consumer = await session.CreateConsumerAsync(destination);
                    await connection.StartAsync();
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        // ReceiveAsync don't accept a cancellation token, therefore use timeout to check cancellation token in
                        // the outer while-loop. If no message is found within timeout, null is returned(and ignored)
                        IMessage message = await consumer.ReceiveAsync(TimeSpan.FromSeconds(15));
                        if (message is ITextMessage textMessage)
                        {
                            _telemetry.TrackTrace("Text message received");
                            _messageHandler.HandleMessage(textMessage.Text);
                            await textMessage.AcknowledgeAsync();
                        }
                        else if (message != null)
                        {
                            Console.WriteLine("Unknown message");
                            string exceptionMessage = "MessageID:" + message.NMSMessageId + ". Only text messages are supported. Message type was: " + message.NMSType;
                            UnkownMessageFormatException exception = new(exceptionMessage);
                            _telemetry.TrackException(exception);

                            // Don't block the queue if an unsupported message arrives
                            await message.AcknowledgeAsync();
                        }
                    }
                }
                catch (NMSException ex)
                {
                    HandleConnectionError(ex);
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                    }
                    catch (Exception)
                    {
                        // It's okay if the delay task is stopped before executing wait
                        return;
                    }
                }
            }
            return;
        }
    }
}