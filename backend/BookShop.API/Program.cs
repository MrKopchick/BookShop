using BookShop.DataAccess;
using Microsoft.EntityFrameworkCore;
using BookShop.Core.Abstractons;
using BookShop.DataAccess.Repositories;
using BookShop.Application.Services;
using BookShop.Core.Abstractions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDBContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookStoreDBContext)));
    });

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


var app = builder.Build();  

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
