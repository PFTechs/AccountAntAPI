using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountAntAPI.Models
{
    [Table("Collections")]
    [PrimaryKey("Id")]
    public class Collection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }

    public class ItemConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            _ = builder;
        }
    }
}
