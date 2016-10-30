using Mepham.Forum.Models.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mepham.Forum.Models.Dtos.Comment
{
    /// <summary>
    /// Class to be used when an in-depth Comment is requried, this also returns 
    /// a recursive in-depth comment for each reply to this comment.
    /// </summary>
    public class DetailedCommentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateTime { get; set; }
        public BasicUserDto Author { get; set; }
        public ICollection<DetailedCommentDto> Replies { get; set; }
    }
}
