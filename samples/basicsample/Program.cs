using Batshark.DeploymentInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDeploymentInfoServicesAll();
builder.Services.AddDeploymentInfoServicesAll(options =>
{
    options.UseHash = UseHash.SHA256;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// this will add the controllers in the Library automagically.
app.MapControllers();

// map, optional options, if not provided defaults is used.
/*app.MapDeploymentServiceInfoAll(options =>
{
    options.ChecksumsRoute = "mycustomchecksumsroute";
    options.WhoamiRoute = "mycustomwhoamiroute";
    options.VersionRoute = "mycustomversionroute";
});*/
// can be called multiple times, here im adding the default checksums as well.
//app.MapDeploymentServiceInfoChecksums();
app.MapDeploymentServiceInfoAll();
app.Run();
