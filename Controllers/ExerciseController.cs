using Microsoft.AspNetCore.Mvc;
using PlayersGuideTrackerApi.Data;
using PlayersGuideTrackerApi.Models;

namespace PlayersGuideTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Exercise>> GetAllExercises()
        {
            var chapterData = MockData.chapters.SelectMany(exercise  => exercise.Exercises).ToList();

            return Ok(chapterData);
        }


        [HttpGet("{chapterId}/exercises/{exerciseId}")]
        public ActionResult<IEnumerable<Exercise>> GetExerciseById(int chapterId, int exerciseId)
        {
            var chapterSearch = MockData.chapters.FirstOrDefault(chapter => chapter.Id == chapterId);

            if(chapterSearch == null)
            {
                return NotFound(new { message = "Chapter not found" });
            }
                
            var result = chapterSearch.Exercises.FirstOrDefault(exercise => exercise.Id == exerciseId);

            if (result == null)
            {
                return NotFound(new { message = $"Exercise with ID {exerciseId} was not found." });
            }

            return Ok(result);
        }

        [HttpPost("{chapterId}/exercises")]
        public ActionResult<Exercise> CreateNewExercise(int chapterId, Exercise newExercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chapter = MockData.chapters.FirstOrDefault(e => e.Id == chapterId);

            newExercise.Id = MockData.chapters.Max(exercise => exercise.Id) + 1;

            if (chapter == null)
            {
                return NotFound(new { message = "Chapter could not be found" });
            }

            newExercise.Id = chapter.Exercises.Any() 
                ? chapter.Exercises.Max(e => e.Id) + 1 
                : 1;

            newExercise.Completed = false;

            chapter.Exercises.Add(newExercise);

            return CreatedAtAction(
                nameof(GetExerciseById),
                new { chapterId = chapter.Id, exerciseId = newExercise.Id },
                newExercise
            );
        }
    }
}
