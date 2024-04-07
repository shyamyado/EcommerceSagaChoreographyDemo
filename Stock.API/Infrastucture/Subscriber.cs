
using RabbitMQEventBus;
using Stock.API.Infrastucture.Repositories;
using Stock.API.Model;

namespace Stock.API.Infrastucture
{
    public class Subscriber : BackgroundService
    {
        private readonly IRabbitMQPersistantConnection _rabbitMQPersistantConnection;
        private readonly IOrderPaymentRespository _orderPaymentRespository;
        private readonly IStockRepository _stockRepository;

        public Subscriber(IRabbitMQPersistantConnection rabbitMQPersistantConnection, IServiceScopeFactory factory)
        {
            _rabbitMQPersistantConnection = rabbitMQPersistantConnection;
            _stockRepository = factory.CreateScope().ServiceProvider.GetRequiredService<IStockRepository>();
            _orderPaymentRespository = factory.CreateScope().ServiceProvider.GetRequiredService<IOrderPaymentRespository>();
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                SubscribeToQueue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex}");
            }
            return Task.CompletedTask;
        }

        private void SubscribeToQueue()
        {
            string eventMsgQueueName = "new_order";
            _rabbitMQPersistantConnection.Subscribe(eventMsgQueueName, HandleMessage);
            Console.WriteLine("Subbscripber is working");
        }

        private void HandleMessage(string message)
        {
            Console.WriteLine($"====Stock Order subscriber============Received message: {message}");
            var stock = Newtonsoft.Json.JsonConvert.DeserializeObject<OrderPayment>(message);
            _orderPaymentRespository.AddOrder(stock);
        }
    }
}
