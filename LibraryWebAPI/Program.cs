using LibraryBLL.Validators;
using LibraryBLL.Interfaces;
using LibraryBLL.Services;
using LibraryBLL.Mappings;
using LibraryDAL.LibraryDbContext;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<SaveBookDTOValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryContext>(opt => opt.UseInMemoryDatabase("LibraryDb"));
builder.Services.AddAutoMapper(typeof(LibraryMappingProfile));
builder.Services.AddScoped<IBooksService, BooksService>();

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
