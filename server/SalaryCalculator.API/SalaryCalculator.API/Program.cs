using Microsoft.EntityFrameworkCore;
using SalaryCalculator.API.DAL;
using SalaryCalculator.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
builder.Services.AddScoped<ISalaryService, SalaryService>();
//builder.Services.AddDbContext<SalaryDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SalaryDb")));
builder.Services.AddDbContext<SalaryDbContext>(options =>
    options.UseInMemoryDatabase("SalaryDb"));
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")  // הכתובת של הקליינט
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SalaryDbContext>();
    db.Database.EnsureCreated();
}
app.UseCors(MyAllowSpecificOrigins);

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
