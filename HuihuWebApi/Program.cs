using HuihuWebApi;
using HuihuWebApi.Controllers;
using HuihuWebApi.Controllers.V1.Authenication;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<AuthenticationFitter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//自写中间件鉴权
//app.UseMiddleware<AuthenticationBase>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<MainMidder>();

InitClass.Init();

app.Run();