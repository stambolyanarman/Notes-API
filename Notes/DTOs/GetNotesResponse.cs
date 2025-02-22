namespace Notes.DTOs
{
    public class GetNotesResponse
    {
        public IEnumerable<NoteDto> Notes { get; set; }
    }
}
