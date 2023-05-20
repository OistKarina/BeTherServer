using BeTherServer.Models;
using BeTherMongoDB.Services;
using BeTherServer.Services;
using BeTherServer.MongoContext;

///hello

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoService"));


builder.Services.AddSingleton<IConnectToAppDBContext,ConnectToAppMongoContext>();
builder.Services.AddSingleton<IPreviousQuestionDBContext, PreviousQuestionsMongoContext>();
builder.Services.AddSingleton<PreviousQuestionsService>();
builder.Services.AddScoped<IConnectToAppService, ConnectToAppService>();
builder.Services.AddSingleton<IPreviousQuestionService, PreviousQuestionsService>();


// Add services to the container
builder.Services.AddControllers();

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
