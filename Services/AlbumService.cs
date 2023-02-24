using DataBaseFirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirstAPI.Services
{
    public class AlbumService : IAlbum
    {
        private readonly DiscografiaContext _context;
        public AlbumService(DiscografiaContext context)
        {
            _context = context;
        }
        public async Task<IResult> Get(int id)
        {
            return await _context.Albums.Include(p => p.Artista).FirstOrDefaultAsync(a => a.AlbumId == id)
                is Album album
                ? TypedResults.Ok(album)
                : TypedResults.NotFound();

        }

        public async Task<IResult> GetAll()
        {
            return TypedResults.Ok(await _context.Albums.Include(p => p.Artista).ToArrayAsync());
        }

        public async Task<IResult> Create(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return TypedResults.Created($"/Album/{album.AlbumId}");
        }

        public async Task<IResult> Delete(int id)
        {
            if(await _context.Albums.FindAsync(id) is Album album)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
                return TypedResults.Ok(album);
            }
            return TypedResults.NotFound();
        }
    }
}
