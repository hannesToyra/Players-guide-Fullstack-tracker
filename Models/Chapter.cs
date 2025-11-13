using System.ComponentModel.DataAnnotations;

namespace PlayersGuideTrackerApi.Models
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(5, ErrorMessage = "Title must be atleast 5 characters long")]
        [MaxLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
