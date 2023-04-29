using Images.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRandomImageService, RandomImageService>();
var allowedOrigins = builder.Configuration
    .GetSection("AllowedOrigins")
    .Get<string[]>();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(name: "Client", corsPolicyBuilder =>
    {
        if (allowedOrigins != null)
            corsPolicyBuilder.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Client");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();