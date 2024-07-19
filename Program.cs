using Ecommerce.Core.IReboseitry;
using Ecommerce.Infastructoure.Reboseitry;
using EcommerceInfastructoure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

			 });
			builder.Services.AddScoped(typeof(IProductRebositery),typeof(ProductRebositery));
			
			//builder.Services.AddScoped(typeof(IGenericRepositry<>),typeof(IGenericRepositry<>));



			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
