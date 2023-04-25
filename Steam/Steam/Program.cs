using Microsoft.EntityFrameworkCore;
using STEAM.Database;
using STEAM.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<DatabaseContext>((_, options) =>
{
    options.UseSnakeCaseNamingConvention();
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"), x =>
    {
        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });
});

// Add services to the container.
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<IPhotosService, PhotosService>();
builder.Services.AddScoped<IContactsService, ContactsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
    // add 5 seconds delay to ensure the db server is up to accept connections
    // this won't be needed in real world application
    Thread.Sleep(5000);
    // context.Database.EnsureCreated();
    context.Database.Migrate();
}

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
