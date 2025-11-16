using System.ComponentModel.DataAnnotations;

namespace PlayersGuideTrackerApi.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Exercise title cannot be null")]
        [MinLength(5, ErrorMessage = "Title must be atleast 5 characters long")]
        [MaxLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public bool Completed { get; set; } = false;
        [Required(ErrorMessage = "Exercise XP cannot be null")]
        [Range(25, 200, ErrorMessage = "XP value must be between 25-200")]
        public int XP { get; set; } = 0;
        public string? SolutionCode { get; set; }
    }
}
