using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaChatApp
{
    public class Consumer
    {
        public static void Start()
        {
            var config = new ConsumerConfig
            {
                GroupId = "chat-consumer-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("chat-topic");

            Console.WriteLine("Listening for messages...");
            while (true)
            {
                var cr = consumer.Consume(CancellationToken.None);
                Console.WriteLine($"Received: {cr.Message.Value}");
            }
        }
    }
}
