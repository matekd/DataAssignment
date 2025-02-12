﻿namespace Business.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;
}
