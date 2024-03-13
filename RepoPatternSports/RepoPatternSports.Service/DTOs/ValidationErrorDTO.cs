namespace RepoPatternSports.Service.DTOs
{
    public class ValidationErrorDTO
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } 

        public ValidationErrorDTO()
        {
            Errors = new List<string>();
        }
    }
}
