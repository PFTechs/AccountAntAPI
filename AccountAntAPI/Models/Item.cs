using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using AccountAntAPI.Models;

namespace AccountAntAPI.Models
{
    [Table("Items")]
    [PrimaryKey("Id")]
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Origin { get; set; }
        public string Comment { get; set; }
        public Guid ContainingCollectionId { get; set; }
        public Collection Collection { get; set; }


        public class ItemConfiguration : IEntityTypeConfiguration<Item>
        {
            public void Configure(EntityTypeBuilder<Item> builder)
            {
                _ = builder;
            }
        }
    }
}
