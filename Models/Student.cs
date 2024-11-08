using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFirstCRUD.Models;

public partial class Student
{
    [Key]
    public int Id { get; set; }
    [Column("StudentName", TypeName = "varchar(100)")]
    [Required]
    public string StudentName { get; set; } = null!;

    [Column("StudentGender", TypeName = "varchar(100)")]
    [Required]
    public string StudentGender { get; set; } = null!;

    [Required]
    public int? Age { get; set; }

    [Required]
    public int? Standard { get; set; }
}
