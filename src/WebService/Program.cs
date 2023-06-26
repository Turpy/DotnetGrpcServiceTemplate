using Microsoft.OpenApi.Models;

// build out the DI pipeline for the web service
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(gen =>
{
    var docFilePath = Path.Combine(System.AppContext.BaseDirectory, nameof(WebService) + ".xml");
    gen.IncludeXmlComments(docFilePath);
    gen.IncludeGrpcXmlComments(docFilePath, includeControllerXmlComments: true);
    gen.SwaggerDoc("v1", new OpenApiInfo { Title = nameof(WebService) + " gRPC transcoding", Version = "v1" });
});
var app = builder.Build();

// configure the HTTP request pipeline.
app.MapGrpcService<WebService.Services.V1.GreeterService>();
app.UseSwagger();
app.UseSwaggerUI(ui =>
{
    ui.SwaggerEndpoint("/swagger/v1/swagger.json", nameof(WebService) + " V1");
    ui.RoutePrefix = "";
});

// start the web service
app.Run();
