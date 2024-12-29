using EnlinqdSurveyManager.Application.Commands.Campaigns;
using EnlinqdSurveyManager.Application.Commands.Orders;
using EnlinqdSurveyManager.Application.Commands.Survey;
using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EnlinqdDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SurveyContext")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IUpdateSurveyCommandHandler, UpdateSurveyCommandHandler>();
            builder.Services.AddScoped<ICampaignCommandHandler, CampaignCommandHandler>();
            builder.Services.AddScoped<IOrderCommandHandler, OrderCommandHandler>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddControllers();

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}