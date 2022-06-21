using System;
using System.Collections.Generic;

namespace Api.Data
{
    public class Post
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<PostUsersLikes> PostUsersLiked { get; set;} = new List<PostUsersLikes>();
    }
}
