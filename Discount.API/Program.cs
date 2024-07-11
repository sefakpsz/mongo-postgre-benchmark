using Discount.API.Extensions;
using Microsoft.OpenApi.Models;
using GraphQL.Server.Ui.Voyager;
using Discount.API.GraphQL;
using Finance.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
});

var app = builder.Build();

app.UseRouting();

app.MapGraphQL();

app.UseGraphQLVoyager(
    path: "/graphql-voyager",
    options: new VoyagerOptions()
    {
        GraphQLEndPoint = "/graphql"
    });

app.MigrateDatabase<Program>();

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