using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TruckPlannerLib;
using TruckPlannerLib.DataRepository;
using TrunkPlannerApi.DataStore;

var builder = WebApplication.CreateBuilder(args);

//Repository using InMemoryStore
builder.Services.AddSingleton<ITruckPlannerRepository>
                (options => new TruckPlannerRepository(new TruckPlannerInMemoryDataStore()));

//Json options to format the response
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DFDS coding task - Khushwant Singh",
        Description = "Documentation for TruckPlanner api - Coding task",
        Contact = new OpenApiContact
        {
            Name = "Khushwant Singh",
        },
        License = new OpenApiLicense
        {
            Name = "DFDS"
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    swagger.IncludeXmlComments(xmlPath);
});

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
