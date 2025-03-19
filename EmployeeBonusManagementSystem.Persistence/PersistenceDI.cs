using System.Data;
using EmployeeBonusManagement.Application.Services;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using EmployeeBonusManagementSystem.Application.Features.Employees.Common;
using EmployeeBonusManagementSystem.Domain.Entities;
using EmployeeBonusManagementSystem.Infrastructure.Repositories;
using EmployeeBonusManagementSystem.Persistence.Factory;
using EmployeeBonusManagementSystem.Persistence.Repositories.Common;
using EmployeeBonusManagementSystem.Persistence.Repositories.Implementations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeBonusManagementSystem.Persistence;

public static class PersistenceDI
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // DB კონტექსტის დამატება 
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IDbConnection>(provider =>
        {
	        return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IDbConnectionFactory>(provider =>
	        new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));

		services.AddScoped<IDbTransaction>(provider =>
        {
	        var connection = provider.GetRequiredService<IDbConnection>();
	        connection.Open();
	        return connection.BeginTransaction();
        });
		services.AddScoped<IEmployeeRepository, EmployeeRepository>();

		

		services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeeService<EmployeeDto>, ManageEmployeesService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoleAssignmentService, RoleAssignmentService>();

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();


		services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<RoleAssignmentService>();
        services.AddScoped<IRequestHandler<AddEmployeeCommand, bool>, AddEmployeeCommandHandler>();


        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IBonusRepository, BonusRepository>();
        services.AddScoped<ISqlQueryRepository, SqlQueryRepository>();
        services.AddScoped<ISqlCommandRepository, SqlCommandRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
		return services;

    }
}

