using System.Text;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using EmployeeBonusManagementSystem.Application.Mapping;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;


// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(); 
    builder.Services.AddAutoMapper(typeof(EmployeeProfile));



	builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddEmployeeCommand).Assembly));


	builder.Services.AddPersistence(builder.Configuration);
     
}

// Configure the HTTP request pipeline.
var app = builder.Build();
{
    //if (app.Environment.IsDevelopment())
    //{
    //    app.UseSwagger();
    //    app.UseSwaggerUI();
    //}

    app.UseSwagger();

    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	    .AddJwtBearer(options =>
	    {
		    options.TokenValidationParameters = new TokenValidationParameters
		    {
			    ValidateIssuer = true,
			    ValidateAudience = true,
			    ValidateLifetime = true,
			    ValidateIssuerSigningKey = true,
			    ValidIssuer = builder.Configuration["Jwt:Issuer"],
			    ValidAudience = builder.Configuration["Jwt:Audience"],
			    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		    };
	    });

    builder.Services.AddAuthorization();

	app.MapControllers();

    app.Run();
}

