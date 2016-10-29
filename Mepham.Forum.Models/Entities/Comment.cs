using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mepham.Forum.Models.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid PostId { get; set; }

        public Guid? ResponseToCommentId { get; set; }

        #region Navigation Properties

        [ForeignKey("AuthorId")]
        public User Author { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("ResponseToCommentId")]
        public Comment ResponseToComment { get; set; }

        #endregion
    }
}
