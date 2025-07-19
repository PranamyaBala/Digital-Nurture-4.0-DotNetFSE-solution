using Confluent.Kafka;


namespace KafkaChatWinApp
{
    public partial class Form1 : Form
    {
        private string topic = "chat-topic";
        private IConsumer<Null, string> consumer;
        public Form1()
        {
            InitializeComponent();

            // Setup consumer
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            consumer = new ConsumerBuilder<Null, string>(config).Build();
            consumer.Subscribe(topic);

            timer1.Interval = 2000; // poll every 2 seconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var consumeResult = consumer.Consume(TimeSpan.FromMilliseconds(100));
                if (consumeResult != null)
                {
                    ChatBox.Items.Add($"Other: {consumeResult.Message.Value}");
                }
            }
            catch (ConsumeException ex)
            {
                MessageBox.Show($"Consume error: {ex.Error.Reason}");
            }
        }

        private System.Windows.Forms.Timer kafkaTimer;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnSend_Click_1(object sender, EventArgs e)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var message = txtMessage.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                ChatBox.Items.Add($"You: {message}");
                txtMessage.Clear();
            }
        }

        private void btnRecieve_Click(object sender, EventArgs e)
        {
            kafkaTimer = new System.Windows.Forms.Timer();
            kafkaTimer.Interval = 2000; // 2 seconds
            kafkaTimer.Tick += KafkaTimer_Tick;
            kafkaTimer.Start();
        }

        private void KafkaTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                var consumeResult = consumer.Consume(TimeSpan.FromSeconds(1));
                if (consumeResult != null)
                {
                    ChatBox.Items.Add($"Received: {consumeResult.Message.Value}\n");
                }
            }
            catch (ConsumeException ex)
            {
                MessageBox.Show($"Error consuming: {ex.Error.Reason}");
            }
        }
    }

}
