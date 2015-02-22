using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.DomainEntity
{
    [Table("LineItem")]
    public class LineItem : AuditableEntity<int>
    {
        [Required]
        [MaxLength(200)]
        public virtual string Name { get; set; }
        
        [MaxLength(50)]
        public virtual string Module { get; set; }
        
        [MaxLength(250)]
        public virtual string Details { get; set; }

        [Required]
        public virtual float DevTime { get; set; }
        
        [Required]
        public virtual float QATime { get; set; }

        //public virtual string Developer { get; set; }

        [Required]
        public virtual LineItemStatus Status { get; set; }

        [MaxLength(500)]
        public virtual string Remark { get; set; }

        [Display(Name = "Iteration")]
        public int IterationOrSprintId { get; set; }

        [ForeignKey("IterationOrSprintId")]
        public virtual IterationOrSprint IterationOrSprint { get; set; }
    }

    public enum LineItemStatus
    {
        None,
        DevOngoing,
        DevDone,
        FixedAtDev,
        FixedAtStg,
        QAOngoing,
        QADone,
        Closed
    }
}
