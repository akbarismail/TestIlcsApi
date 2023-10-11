using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestIlcsApi.Entities;

[Table(("m_country"))]
public class Country
{
    [Key, Column("id")]
    public Guid Id { get; set; }
    
    [Column("name", TypeName = "NVarchar(50)")]
    public string? Name { get; set; }
    
    [Column("code", TypeName = "NVarchar(10)")]
    public string? Code { get; set; }
    
    [Column("char", TypeName = "NVarchar(3)")]
    public string? Char { get; set; }
}