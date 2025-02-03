using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Index(nameof(Status), IsUnique = true)]
public class StatusTypeEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Status { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
