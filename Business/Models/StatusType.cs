using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class StatusType
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;
}

public class StatusTypeRegistrationForm
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Status { get; set; } = null!;
}

public class StatusTypeUpdateForm
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;
}