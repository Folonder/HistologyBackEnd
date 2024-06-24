using Gallery.Data;
using Gallery.Mappers;
using Gallery.Middleware;
using Gallery.Repositories;
using Gallery.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Since the application can run on both Windows and Linux, the type of path to the database will be different.
// In order for the docker to synchronize with the host, the database must be located in a folder.
var dbPath = Path.Combine("Database", "shop_api_database.db");
builder.Configuration["ConnectionStrings:SQLiteConnection"] = $"Data Source={dbPath}";

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddDbContext<GalleryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));
builder.Services.Configure<ClassifierServiceOptions>(builder.Configuration.GetSection(ClassifierServiceOptions.Key));
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IClassifierService, ClassifierService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();