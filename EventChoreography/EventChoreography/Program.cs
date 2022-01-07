using EventChoreography.BusinessLogic;
using EventChoreography.MessageHandlers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<TicketService>();
builder.Services.AddSingleton<FlightService>();
builder.Services.AddSingleton<HotelService>();
builder.Services.AddSingleton<PaymentService>();
builder.Services.AddSingleton<NotificationService>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<TripOrderedHandler>();
    x.AddConsumer<TicketBoughtHandler>();
    x.AddConsumer<FlightBookedHandler>();
    x.AddConsumer<HotelBookedHandler>();
    x.AddConsumer<HotelBookingFailedHandler>();
    x.AddConsumer<FlightBookingFailedHandler>();
    x.AddConsumer<TicketReturnedHandler>();

    x.UsingInMemory((ctx, cfg) =>
    {
        cfg.ConfigureEndpoints(ctx);
    });
});

builder.Services.AddMassTransitHostedService();

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
