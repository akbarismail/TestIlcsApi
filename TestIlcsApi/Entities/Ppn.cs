using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestIlcsApi.Entities;

[Table("m_ppn")]
public class Ppn
{
    [Key, Column("id")]
    public Guid Id { get; set; }
    
    [Column("percent")]
    public int Percent { get; set; }
    
    [Column("product_id")]
    public Guid ProductId { get; set; }

    public virtual Product? Product { get; set; }
}