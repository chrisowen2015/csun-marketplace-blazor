using System;
using System.Collections.Generic;

namespace csun_marketplace.data
{
    public partial class SavedForLaterVM
    {
        public int SavedForLaterId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; } = null!;
        public Product product { get; set; } = new Product();
    }
}
