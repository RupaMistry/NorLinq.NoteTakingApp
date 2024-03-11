var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging(opt =>
{
    opt.AddDebug();
    opt.AddConsole();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NotesAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotesDBConnection"));
});

builder.Services.AddScoped<INotesService<Note>, NotesService>();
builder.Services.AddScoped<IRepository<Note>, NotesRepository>();

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
