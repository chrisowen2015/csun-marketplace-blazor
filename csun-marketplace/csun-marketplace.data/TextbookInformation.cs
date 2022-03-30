using System;
using System.Collections.Generic;

namespace csun_marketplace.data
{
    public partial class TextbookInformation
    {
        public int TextbookInformationId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string? Authors { get; set; }
        public string? Edition { get; set; }
        public string? Isbn { get; set; }
        public string? Course { get; set; }
        public string? Department { get; set; }
        public string? Condition { get; set; }
    }
}
