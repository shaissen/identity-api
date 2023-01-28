using Pendulum.Identity.Data.Dependency;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Service.Dependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDataDependency();
builder.Services.AddServiceDependency();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtSchemeAuthentication(jwt =>
{
    var jwtValues = builder.Configuration.GetSection("JwtCredentials");

    jwt.Key = jwtValues.GetSection("Key").Value;
    jwt.Issuer = jwtValues.GetSection("Issuer").Value;
    jwt.Audience = jwtValues.GetSection("Audience").Value;

});

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));


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
