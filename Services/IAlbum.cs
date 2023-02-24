using DataBaseFirstAPI.Models;

namespace DataBaseFirstAPI.Services
{
    public interface IAlbum
    {
        public Task<IResult> GetAll();
        public Task<IResult> Get(int id);
        public Task<IResult> Create(Album album);
        public Task<IResult> Delete(int id);
    }
}
