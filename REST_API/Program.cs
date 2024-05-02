using Microsoft.EntityFrameworkCore;
using REST_API.DataLayer;
using REST_API.Managers;
using REST_API.Services;
using REST_API.Controllers;
using System.Runtime.ConstrainedExecution;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped< IUserResultService,  UserResultService > ();
builder.Services.AddScoped<IUserResultManager, UserResultManager>();
builder.Services.AddScoped<IQsnViewService, QsnViewService>();
builder.Services.AddScoped<IQuestionViewManager, QuestionViewManager>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IAnswerManager, AnswerManager>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionManager, QuestionManager>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleManager, ArticleManager>();
// builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
// builder.Services.AddSingleton<IArticleRepository, ArticleRepository>();

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

//app.MapQAnswerEndpoints();

 app.Run();
