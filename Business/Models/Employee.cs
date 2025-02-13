using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;
}

public class EmployeeRegistrationForm
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Role { get; set; } = null!;
}

public class EmployeeUpdateForm
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;
}