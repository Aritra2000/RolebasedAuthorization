using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class EmployeeList
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Ph { get; set; } = null!;
}
