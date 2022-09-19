using Microsoft.EntityFrameworkCore;
using SpaceAllocationTool.Common;
using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Allow CORS
        builder.Services.AddCors(options => {
            options.AddPolicy(name: "CustomPolicy",
                policy => {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
            });
        });

        builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<SpaceAllocationToolContext>(o => {
            o.UseSqlite(builder.Configuration.GetConnectionString(Constants.SATDB));
            o.UseLazyLoadingProxies();
        });

        builder.Services.AddTransient<IBuildingsRepository, BuildingsRepository>();
        builder.Services.AddTransient<IDepartmentsRepository, DepartmentsRepository>();
        builder.Services.AddTransient<IEmployeeLevelsRepository, EmployeeLevelsRepository>();
        builder.Services.AddTransient<IEmployeeOrganizationsRepository, EmployeeOrganizationsRepository>();
        builder.Services.AddTransient<IEmployeeRolesRepository, EmployeeRolesRepository>();
        builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();
        builder.Services.AddTransient<IFloorsRepository, FloorsRepository>();
        builder.Services.AddTransient<IOeCodesRepository, OeCodesRepository>();
        builder.Services.AddTransient<IRoomsRepository, RoomsRepository>();
        builder.Services.AddTransient<ISeatsRepository, SeatsRepository>();
        builder.Services.AddTransient<IWingsRepository, WingsRepository>();
        builder.Services.AddTransient<IAllocationRepository, AllocationRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("CustomPolicy");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}