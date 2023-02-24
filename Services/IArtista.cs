using DataBaseFirstAPI.Models;

namespace DataBaseFirstAPI.Services
{
    public interface IArtista
    {
        public Task<IResult> GetAll();
        public Task<IResult> Get(int id);
        public Task<IResult> Create(Artista artista);
        public Task<IResult> Delete(int id);
    }
}
