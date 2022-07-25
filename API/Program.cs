using API.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//setting DBcontext
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// RepositoryAccessor and Service
builder.Services.AddDependencyInjectionConfiguration();

// Add Authentication
builder.Services.AddAuthenticationConfigufation(builder.Configuration);

//Swagger Config
builder.Services.AddSwaggerGenConfiguration();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseRouting();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
