using HelperIT.Persistance;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
options.AddPolicy(name: "AllowAllOrigins",// testowe 
builder =>
{
    builder.AllowAnyOrigin();
}));
builder.Services.AddCors(options =>
options.AddPolicy(name: "PrivateOrigins",// whitelist
builder =>
{
    builder.WithOrigins("https://"); // adres i port frontendu np. https://localhost:44359
}));
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "HelperIT",
        Version = "v1",
        Description = "Web application for service online",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "JarekJ",
            Email = "jarek@hkr.net.pl",
            Url = new Uri("https://example.com")

        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Used license",
            Url = new Uri("https://example.com")
        }
    }));
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHealthChecks("/hc");
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
