using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

JsonSerializerOptions options = new()
{
    WriteIndented = true,
    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
};

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vsProject\DataAssignment\Data\Databases\database.mdf;Integrated Security=True;Connect Timeout=30"));
serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
serviceCollection.AddScoped<IServiceRepository, ServiceRepository>();
serviceCollection.AddScoped<IStatusTypeRepository, StatusTypeRepository>();
serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();

serviceCollection.AddScoped<IProjectService, ProjectService>();

var serviceProvider = serviceCollection.BuildServiceProvider();

IEnumerable<Project> projects = await serviceProvider.GetService<IProjectService>()!.GetProjectsAsync();

foreach (var project in projects)
{
    var json = JsonSerializer.Serialize(project, options);
    Console.WriteLine(json);
}