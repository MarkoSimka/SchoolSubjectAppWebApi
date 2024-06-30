using Microsoft.AspNetCore.Mvc;

namespace SchoolSubjectsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolSubjectController : ControllerBase
    {
        private static readonly string[] _names = new[]
        {
            "Physics", "History", "Biology"
        };

        private static readonly string[] _descriptions = new[]
        {
            "Study of matter and energy and the interactions between them.", "Study of past events and their impact on the present.", "Study of living organisms and their vital processes."
        };

        private static readonly string[] _books = new[]
        {
            "Principles studies", "Modern studies", "studies 101"
        };

        private readonly ILogger<SchoolSubjectController> _logger;

        public SchoolSubjectController(ILogger<SchoolSubjectController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSchoolSubjects")]
        public IEnumerable<Subject> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Subject
            {
                Id = Guid.NewGuid(),
                Name = $"{_names[Random.Shared.Next(_names.Length)]} {index}",
                Description = $"{_descriptions[Random.Shared.Next(_descriptions.Length)]}",
                WeeklyClasses = Random.Shared.Next(1, 10),
                LiteratureUsed = new List<string> { $"{_books[Random.Shared.Next(_books.Length)]} {index}" },
                AdditionalProperties = new AdditionalProperties
                {
                    Teacher = $"Teacher {index}",
                    Room = $"Room {index}",
                    GradeLevel = $"Grade-{index}"
                }
            })
            .ToArray();
        }
    }
}
