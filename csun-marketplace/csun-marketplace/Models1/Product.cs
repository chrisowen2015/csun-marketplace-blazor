using System;
using System.Collections.Generic;

namespace csun_marketplace.Models1
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int OwnerId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Available { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
        public byte[]? ImageSource { get; set; }
    }
}
