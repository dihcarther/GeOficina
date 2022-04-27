using GeOficina.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.







builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextoDb>(options => options.UseMySql("server=localhost;initial catalog=Oficina;uid=root;pwd=#di3ck202", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"), providerOptions => providerOptions.EnableRetryOnFailure()));




builder.Services.AddDefaultIdentity<IdentityUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ContextoDb>()
        .AddDefaultTokenProviders();

 

var app = builder.Build();







// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
