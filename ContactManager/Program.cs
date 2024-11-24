//Kenny Hedlund
//Chapter 4 Contact 
//COP.4813

using ContactManager;

var builder = WebApplication.CreateBuilder(args);

// Use the Startup class for configuration
var startup = new Startup(builder.Configuration);

// Configure services (Dependency Injection)
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline
startup.Configure(app, builder.Environment);

app.Run();

