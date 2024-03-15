using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public partial class TblUser
{
    public int Id { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Ph { get; set; } = null!;

    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [NotMapped]
    public string? Role { get; set; }
}
