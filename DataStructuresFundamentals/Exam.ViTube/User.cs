using System.Collections.Generic;

namespace Exam.ViTube
{
    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int LikedOrDisliked { get; set; }

        public int Watched { get; set; }

        public User(string id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
