using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Errors;
using shop_api.Extensions;
using shop_api.Middleware;
using shop_api.Models;
using shop_api.Repository.Interfaces;
using shop_api.Repository.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices(builder.Configuration); // all the services and dependencies injenctions are stored here

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

//request comes and no endpoint that matches request
//it will redirect to error controller and pass the status code
app.UseStatusCodePagesWithReExecute("/errors/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // this method i can use the images that were saved locally at wwwroot

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
