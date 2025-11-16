using Citify.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddIdentityLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddApiCors();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

app.UseGlobalExceptionHandler();
app.UseSwaggerDocumentation();
app.UseHttpsRedirection();
app.UseCors("DefaultCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.ApplyMigrationsAsync();
await app.SeedDevelopmentDataAsync();

app.Run();
