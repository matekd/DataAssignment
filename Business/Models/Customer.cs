using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;
}

public class CustomerRegistrationForm
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ContactPerson { get; set; } = null!;
}

public class CustomerUpdateForm
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;
}