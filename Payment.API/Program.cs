
<<<<<<< Updated upstream
=======
using Payment.API.Infrastructure;
using Payment.API.Infrastructure.Repositories;
using Payment.API.Services;

>>>>>>> Stashed changes
namespace Payment.API
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

<<<<<<< Updated upstream
=======
            builder.Services.AddDbContext<PaymentDBContext>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IPaymentService, PaymentServices>();

>>>>>>> Stashed changes
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
