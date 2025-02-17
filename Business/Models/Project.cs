﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;

    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = null!;

    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = null!;

    public int StatusId { get; set; }
    public string Status { get; set; } = null!;
}

public class ProjectRegistrationForm
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public int ServiceId { get; set; }

    [Required]
    public int StatusId { get; set; }
}

public class ProjectUpdateForm
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public int ServiceId { get; set; }

    public int StatusId { get; set; }
}