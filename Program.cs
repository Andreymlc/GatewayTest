using GatewayTest;
using GatewayTest.Schema.Mutation;
using GatewayTest.Schema.Query;
using GatewayTest.Schema.Subscription;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ElementDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IElementService, ElementService>();
builder.Services.AddScoped<Query>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();


var app = builder.Build();

app.MapGraphQLHttp("graphql/http")
    .AllowAnonymous()
    .WithOptions(new GraphQLHttpOptions
    {
        EnableGetRequests = false
    });

app.MapGet("/", async (ElementDbContext context) =>
{
    await context.Elements.AddRangeAsync(Data.GenerateData(100));
    await context.SaveChangesAsync();
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseWebSockets();
app.MapGraphQL();

app.Run();
