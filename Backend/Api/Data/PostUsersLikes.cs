using System;
using System.Collections.Generic;

namespace Api.Data
{
    public class PostUsersLikes
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
