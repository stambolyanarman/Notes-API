using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.DTOs;
using Notes.Interfaces;
using Notes.Models;
using System.Linq.Expressions;

namespace Notes.Services
{
    public class NotesService : INotesService
    {
        private readonly NotesDbContext _context;
        public NotesService(NotesDbContext context)
        {
            _context = context;
        }
        public async Task CreateNote(CreateNoteRequest requestModel, CancellationToken cancellationToken = default)
        {
            var note = new Note(requestModel.Title, requestModel.Description);

            await _context.Notes.AddAsync(note,cancellationToken);
            await _context.SaveChangesAsync();

        }
        public async Task<GetNotesResponse> GetNotes(GetNotesRequest request, CancellationToken cancellationToken = default)
        {
            var noteSearchQuery = _context.Notes.Where(
                x => string.IsNullOrWhiteSpace(request.Search) || x.Title.ToLower().Contains(request.Search.ToLower()));

            Expression<Func<Note, object>> selectorKey = request.SortItem?.ToLower() switch
            {
                "title" => x => x.Title,
                "date" => x => x.CreatedAt,
                _ => x => x.Id,
            };

            if (request.SortOrder == "desc")
            {
                noteSearchQuery = noteSearchQuery.OrderByDescending(selectorKey);
            }
            else
            {
                noteSearchQuery = noteSearchQuery.OrderBy(selectorKey);
            }

            var noteDtos = await noteSearchQuery.Select(x => new NoteDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            }).ToListAsync(cancellationToken);

            return new GetNotesResponse
            {
                Notes = noteDtos
            };
        }

    }
}
