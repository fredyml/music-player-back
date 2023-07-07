using music_player.Core.Entities;
using music_player.Core.Interfaces;
using music_player.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<SpotifySettings>(builder.Configuration.GetSection("Spotify"));
builder.Services.AddHttpClient();
builder.Services.AddScoped<ISpotifyService, SpotifyService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
