using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private List<User> users = new List<User>();
        private List<Video> videos = new List<Video>();

        public bool Contains(User user) => users.Contains(user);

        public bool Contains(Video video) => videos.Contains(video);

        public void DislikeVideo(User user, Video video)
        {
            LikeOrDislikeVideo(user, video);
        }

        private void LikeOrDislikeVideo(User user, Video video)
        {
            if (!users.Contains(user) || !videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Dislikes++;
            user.LikedOrDisliked++;
        }

        public IEnumerable<User> GetPassiveUsers() => users.Where(u => u.Watched == 0 && u.LikedOrDisliked == 0);

        public IEnumerable<User> GetUsersByActivityThenByName() => users.OrderByDescending(u => u.Watched)
            .ThenByDescending(u => u.LikedOrDisliked).ThenBy(u => u.Username);

        public IEnumerable<Video> GetVideos() => videos;

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes() => videos
            .OrderByDescending(v => v.Views)
            .ThenByDescending(v => v.Likes).ThenBy(v => v.Dislikes);

        public void LikeVideo(User user, Video video)
        {
            LikeOrDislikeVideo(user, video);
        }

        public void PostVideo(Video video)
        {
            videos.Add(video);
        }

        public void RegisterUser(User user)
        {
            users.Add(user);
        }

        public void WatchVideo(User user, Video video)
        {
            if (!users.Contains(user) || !videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Views++;
            user.Watched++;
        }
    }
}
