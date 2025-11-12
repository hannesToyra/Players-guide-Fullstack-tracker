namespace PlayersGuideTrackerApi.Models
{
    public class User
    {
        public string Name { get; set; } = "";
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;
        public int CurrentChapterId { get; set; }
        public int CurrentExcerciseId { get; set; }
        public int CurrentPage { get; set; }
    }
}
