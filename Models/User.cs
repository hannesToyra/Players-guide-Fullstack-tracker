using System.ComponentModel.DataAnnotations;

namespace PlayersGuideTrackerApi.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "Name must be atleast 5 characters long")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; } = "";
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;
        public int CurrentChapterId { get; set; }
        public int CurrentExcerciseId { get; set; }
        public int CurrentPage { get; set; }
    }
}
