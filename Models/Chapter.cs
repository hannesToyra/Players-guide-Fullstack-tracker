using System.ComponentModel.DataAnnotations;

namespace PlayersGuideTrackerApi.Models
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters long")]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
