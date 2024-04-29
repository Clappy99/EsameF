using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Traccia1.BLL.Services;
using Traccia1.BLL.Services.Interfaces;
using Traccia1.DAL;
using Traccia1.DAL.Entities;
using Traccia1.DAL.Repositories;
using Traccia1.DAL.Repositories.Interfaces;
using Traccia1.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDbConnection"));
    options.EnableSensitiveDataLogging();
},ServiceLifetime.Scoped);

builder.Services.AddScoped<IBookService,BookService>();

builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
    {
        IgnoreIsSpecifiedMembers = true,
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors",builder =>
    {
        builder
            .WithOrigins("http://localhost:4200","https://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
