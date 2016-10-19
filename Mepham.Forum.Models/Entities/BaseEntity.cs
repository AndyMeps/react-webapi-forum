using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mepham.Forum.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        [DefaultValue("NEWID()")]
        public Guid Id { get; set; }

        [Required]
        [DefaultValue("GETDATE()")]
        public DateTime CreateDateTime { get; set; }
        
        public DateTime? UpdateDateTime { get; set; }
        
        public DateTime? DeleteDateTime { get; set; }
    }
}
