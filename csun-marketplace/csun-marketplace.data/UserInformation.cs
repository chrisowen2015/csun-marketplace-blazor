using System;
using System.Collections.Generic;

namespace csun_marketplace.data
{
    public partial class UserInformation
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Bio { get; set; }
        public DateTime JoinDate { get; set; }
        public byte Rating { get; set; }
        public string? Major { get; set; }
        public string? Gender { get; set; }
    }
}
