using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.DAL.Models
{
    public class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedAtId { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
