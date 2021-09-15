using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public string Text { get; init; }
        [Required]
        public bool Checked { get; init; }
    }
}