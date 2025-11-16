using PlayersGuideTrackerApi.Models;

namespace PlayersGuideTrackerApi.Data
{
    public static class MockData
    {
        public static List<Chapter> chapters = new List<Chapter>()
        {
            new Chapter
            {
                Id = 1,
                Title = "Chapter 1 – The Thing Namer 3000",
                Description = "Learn to output text and interact with the console.",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        Id = 1,
                        Title = "Thing Namer 3000",
                        Description = "Write a program that names things.",
                        Completed = false,
                        XP = 100
                    },
                    new Exercise
                    {
                        Id = 2,
                        Title = "The Makings of a Variable",
                        Description = "Practice variable creation.",
                        Completed = true,
                        XP = 50,
                        SolutionCode = "Console.WriteLine(\"Hello World!\");"
                    }
                }
            }
        };
    }
}
