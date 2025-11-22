using System;

namespace YouTubeVideos
{
    public class Comment
    {
        private string _commenterName;
        private string _text;
        private bool _isApproved;

        public Comment(string commenterName, string text, bool isApproved = false)
        {
            _commenterName = commenterName;
            _text = text;
            _isApproved = isApproved;
        }

        public void Display()
        {
            Console.WriteLine($"{_commenterName}: {_text}");
        }
    }
}
