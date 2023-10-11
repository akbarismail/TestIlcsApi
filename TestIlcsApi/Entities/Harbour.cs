using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestIlcsApi.Entities;

[Table(("m_harbour"))]
public class Harbour
{
    [Key, Column("id")]
    public Guid Id { get; set; }
    
    [Column("name", TypeName = "NVarchar(50)")]
    public string? Name { get; set; }
    
    [Column("country_id")]
    public Guid CountryId { get; set; }
    
    [Column("char", TypeName = "NVarchar(3)")]
    public string? Char { get; set; }

    public virtual Country? Country { get; set; }
}