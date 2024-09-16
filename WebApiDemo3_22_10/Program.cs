using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApiDemo3_22_10.Data;
using WebApiDemo3_22_10.Formatters;
using WebApiDemo3_22_10.Middlewares;
using WebApiDemo3_22_10.Repositories.Abstract;
using WebApiDemo3_22_10.Repositories.Concrete;
using WebApiDemo3_22_10.Services.Abstract;
using WebApiDemo3_22_10.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Add(new TextCsvOutputFormatter());
    options.InputFormatters.Add(new TextCsvInputFormatter());
})
.AddMvcOptions(options =>
{
    options.FormatterMappings.SetMediaTypeMappingForFormat("csv", "text/csv");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<StudentDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Account/SignIn";
        options.LogoutPath = "/Account/SignOut";
    });

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
