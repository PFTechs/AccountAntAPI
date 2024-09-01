using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AccountAntAPI.Models
{
    [Table("Collections")]
    [PrimaryKey("Id")]
    public class Collection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Archived { get; set; }
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
