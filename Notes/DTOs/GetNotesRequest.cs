namespace Notes.DTOs
{
    public class GetNotesRequest
    {
        public string? Search { get; set; }
        public string? SortItem { get; set; }
        public string? SortOrder { get; set; }
    }
}
