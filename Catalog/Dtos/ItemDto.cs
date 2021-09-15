using System;

namespace Catalog.Dtos{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string Text { get; init; }
        public bool Checked { get; init; }  
    }
}