namespace ConferenceDemoApp.Sessions
{
    public class Session
    {
        public int Id { get; set; }
        public int SpeakerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public bool IsFavorite { get; set; }
    }
}