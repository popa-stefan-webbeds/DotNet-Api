using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Text { get; init; }
        [Required]
        public bool Checked { get; init; }
    }
}