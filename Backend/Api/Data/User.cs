using System;
using System.Collections.Generic;

namespace Api.Data
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public DateTime? DateCreated { get; set; }
        public Address Address { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<PostUsersLikes> PostUsersLiked { get; set;} = new List<PostUsersLikes>();
    }
}
