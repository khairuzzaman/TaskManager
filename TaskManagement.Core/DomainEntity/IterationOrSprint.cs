using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.DomainEntity
{
    public class IterationOrSprint : Entity<int>
    {
        [Required]
        [MaxLength(100)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public virtual string Scope { get; set; }

        public virtual DateTime? StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual IEnumerable<LineItem> LineItems { get; set; }
    }
}
