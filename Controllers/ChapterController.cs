using Microsoft.AspNetCore.Mvc;
using PlayersGuideTrackerApi.Data;
using PlayersGuideTrackerApi.Models;

namespace PlayersGuideTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChapterController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Chapter>> GetAllChapters()
        {
            return Ok(MockData.chapters);
        }

        [HttpGet("{chapterId}")]
        public ActionResult<IEnumerable<Chapter>> GetChapterById(int chapterId)
        {
            var result = MockData.chapters.FirstOrDefault(c => c.Id == chapterId);

            if (result == null)
            {
                return NotFound(new { message = $"Chapter with ID {chapterId} was not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Chapter> CreateNewChapter(Chapter chapter)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            chapter.Id = MockData.chapters.Max(chapter => chapter.Id) + 1;
            MockData.chapters.Add(chapter);

            return CreatedAtAction(
                nameof(GetChapterById),
                new { id = chapter.Id },
                chapter
            );
        }

        [HttpPut("{chapterId}")]
        public ActionResult<IEnumerable<Chapter>> EditChapter(int chapterId, Chapter chapter)
        {
            var chapterToEdit = MockData.chapters.FirstOrDefault(c => c.Id == chapterId);

            if(chapterToEdit == null)
            {
                return NotFound(new { message = $"The chapter with id: {chapterId} could not be found." });
            }

            chapterToEdit.Title = chapter.Title ?? chapterToEdit.Title;
            chapterToEdit.Description = chapter.Description ?? chapterToEdit.Description;
            chapterToEdit.Exercises = chapter.Exercises ?? chapterToEdit.Exercises;

            return Ok(chapterToEdit);
        }


        [HttpGet("{chapterId}/exercises")]
        public ActionResult<IEnumerable<Chapter>> GetAllExercisesInChapter(int chapterId)
        {
            var result = MockData.chapters.FirstOrDefault(c =>  c.Id == chapterId);

            if(result == null)
            {
                return BadRequest(new { message = $"The chapter with {chapterId} could not be found." });
            }

            return Ok(result.Exercises);
        }
    }
}
