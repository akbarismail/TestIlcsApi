using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestIlcsApi.Entities;

[Table(("m_product"))]
public class Product
{
    [Key, Column("id")]
    public Guid Id { get; set; }
    
    [Column("code_product", TypeName = "NVarchar(10)")]
    public string? CodeProduct { get; set; }
    
    [Column("name", TypeName = "NVarchar(50)")]
    public string? Name { get; set; }
    
    [Column("price")]
    public long Price { get; set; }
}