using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mepham.Forum.Models.Entities
{
    public class Topic : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid ModeratingUserId { get; set; }


        #region Navigation Properties

        [ForeignKey("ModeratingUserId")]
        public virtual User ModeratingUser { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }

        #endregion
    }
}
