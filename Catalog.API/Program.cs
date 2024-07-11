using ContentMongo.API.Data;
using ContentMongo.API.Repositories;
using Microsoft.OpenApi.Models;
using GraphQL.Server.Ui.Voyager;
using Catalog.API.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IContentContext, ContentContext>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

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