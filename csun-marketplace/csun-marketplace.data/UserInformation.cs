using System;
using System.Collections.Generic;

namespace csun_marketplace.data
{
    public partial class UserInformation
    {
        public string UserId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public DateTime JoinDate { get; set; }
        public byte Rating { get; set; }
        public string? Major { get; set; }
        public string? Gender { get; set; }
    }
}
