using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.DomainEntity
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
    }

    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {

        [ScaffoldColumn(false)]
        [MaxLength(256)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(256)]
        public string ModifiedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime ModifiedDate { get; set; }
    }
}
