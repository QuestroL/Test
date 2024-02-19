using Autofac.Extensions.DependencyInjection;
using Autofac;
using Test.Util;
using Services;
using DataLayer.Repository;
using DataLayer;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using FluentValidation;
using Services.Commands;
using Services.Commands.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        container.RegisterType<CommentsRepository>().As<ICommentsRepository>().WithParameter("dbContext", new DataContext());
        container.RegisterType<CommentService>().As<ICommentService>();
    });


builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssemblyContaining<CreateUserCommentCommand>();
    conf.RegisterValidatorsFromAssemblyContaining<CreateUserCommentCommand>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("VueCorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin() // Разрешить запросы с любого домена
            .AllowAnyMethod() // Разрешить любые HTTP-методы (GET, POST и т.д.)
            .AllowAnyHeader(); // Разрешить любые HTTP-заголовки
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => 
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
} );

var app = builder.Build();

app.UseCors("VueCorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => 
    {
        x.SwaggerEndpoint("v1/swagger.json", "Test API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



