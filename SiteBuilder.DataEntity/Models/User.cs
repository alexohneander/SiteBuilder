using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SiteBuilder.DataEntity.Models
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string Password { get; set; }

        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
