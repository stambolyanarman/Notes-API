using Notes.DTOs;

namespace Notes.Interfaces
{
    public interface INotesService
    {
        public Task CreateNote(CreateNoteRequest requestModel,CancellationToken cancellationToken = default);
        public Task<GetNotesResponse> GetNotes(GetNotesRequest request, CancellationToken cancellationToken = default);
    }
}
