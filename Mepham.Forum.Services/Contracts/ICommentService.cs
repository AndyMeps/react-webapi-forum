using Mepham.Forum.Models.Entities;
using System;
using System.Collections.Generic;

namespace Mepham.Forum.Services.Contracts
{
    /// <summary>
    /// Provides access to the Comment entity.
    /// </summary>
    public interface ICommentService : IBaseService<Comment>
    {
        /// <summary>
        /// Allow us to get comments relating to a specified post.
        /// Overloads the Guid version.
        /// </summary>
        /// <param name="id">Unique ID of the post interested in.</param>
        /// <returns></returns>
        ICollection<Comment> GetByPostId(string id);

        /// <summary>
        /// Allows us to get comments relating to a specified post.
        /// </summary>
        /// <param name="id">Unique ID of the post interested in.</param>
        /// <returns></returns>
        ICollection<Comment> GetByPostId(Guid id);
    }
}
