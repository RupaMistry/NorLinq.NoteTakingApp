using NorLinq.NoteTakingApp.Domain;
using NorLinq.NoteTakingApp.Domain.Core;

namespace NorLinq.NoteTakingApp.Application.Core
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<Note>> GetAll();

        Task<Note> Get(int ID);

        Task<int> Add(Note note);

        Task<Note> Update(int ID, Note note);

        Task<int> Delete(int ID);
    }
}
