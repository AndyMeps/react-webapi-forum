using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mepham.Forum.Models.Dtos.Topic
{
    public class CreateTopicDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        
        [Required]
        public Guid ModeratingUserId { get; set; }
    }
}
