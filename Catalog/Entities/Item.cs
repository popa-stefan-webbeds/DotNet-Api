using System;

namespace Catalog.Entities
{
    public record Item
    {
        public Guid Id { get; init; }
        public string Text { get; init; }
        public bool Checked { get; init; }   
    }
}