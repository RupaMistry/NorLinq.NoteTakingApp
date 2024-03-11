using Microsoft.EntityFrameworkCore;
using NorLinq.NoteTakingApp.Application.Core;
using NorLinq.NoteTakingApp.Domain;

namespace NorLinq.NoteTakingApp.Infrastructure.Repository
{
    public class NotesRepository : IRepository<Note>
    {
        private readonly NotesAppContext _notesAppContext;

        public NotesRepository(NotesAppContext dbContext) => this._notesAppContext = dbContext;

        public async Task<IReadOnlyList<Note>> GetAll()
        {
            var notes = await this._notesAppContext.Notes.OrderBy(n => n.CreatedDate).ToListAsync();

            return notes;
        }

        public async Task<Note> Get(int ID)
        {
            var note = await this._notesAppContext.Notes.FirstOrDefaultAsync(n => n.ID == ID);

            return note;
        }

        public async Task<int> Add(Note note)
        {
            note.ID = 0;
            note.CreatedDate = DateTime.Now;

            this._notesAppContext.Notes.Add(note);

            int rowsAffected = await this._notesAppContext.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<Note> Update(int ID, Note note)
        {
            var checkNote = await this._notesAppContext.Notes
                .AsNoTracking()
                .FirstOrDefaultAsync(n=>n.ID==ID);

            if (checkNote == null)
                return null;

            this._notesAppContext.Entry(note).State = EntityState.Modified;

            await this._notesAppContext.SaveChangesAsync();
           
            return note;
        }

        public async Task<int> Delete(int ID)
        {
            var note = await this._notesAppContext.Notes.FindAsync(ID);

            if (note == null)
                return -1;

            this._notesAppContext.Notes.Remove(note);

            int rowsAffected = await this._notesAppContext.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
