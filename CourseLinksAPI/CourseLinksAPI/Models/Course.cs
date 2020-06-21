namespace CourseLinksAPI.Models
{
    public class Course
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}