using NorLinq.NoteTakingApp.Application.Core;
using NorLinq.NoteTakingApp.Domain;

namespace NorLinq.NoteTakingApp.Application.Services
{
    public class NotesService : INotesService<Note>
    {
        private readonly IRepository<Note> repository;

        public NotesService(IRepository<Note> repository) => this.repository = repository;

        public async Task<IReadOnlyList<Note>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Note> Get(int ID)
        {
            return await repository.Get(ID);
        }

        public async Task<int> Add(Note note)
        {
            return await repository.Add(note);
        }

        public async Task<Note> Update(int ID, Note note)
        {
            return await repository.Update(ID, note);
        }
        public async Task<int> Delete(int ID)
        {
            return await repository.Delete(ID);
        }
    }
}
