
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
using Payment.API.Infrastructure;
using Payment.API.Infrastructure.Repositories;
using Payment.API.Services;

>>>>>>> Stashed changes
=======
using Payment.API.Infrastructure;

>>>>>>> 6c78a3ef1e90890ea995f592b7bb7656ca2384f4
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

<<<<<<< HEAD
<<<<<<< Updated upstream
=======
            builder.Services.AddDbContext<PaymentDBContext>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IPaymentService, PaymentServices>();

>>>>>>> Stashed changes
=======
            builder.Services.AddDbContext<PaymentDBContext>();

>>>>>>> 6c78a3ef1e90890ea995f592b7bb7656ca2384f4
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
