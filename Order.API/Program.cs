
using Microsoft.EntityFrameworkCore;
using Order.API.Infrastructure;
using Order.API.Infrastructure.Repositories;
using Order.API.Services;
using RabbitMQ.Client;
using RabbitMQEventBus;

namespace Order.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IRabbitMQPersistantConnection>(sp =>
            {
                var factory = new ConnectionFactory { HostName = "localhost", UserName = "user01", Password = "123", Port = 5672, };
                return new RabbitMQPersistantConnection(factory);
            });

            builder.Services.AddDbContext<OrderDBContext>();
     
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
