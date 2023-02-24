using DataBaseFirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirstAPI.Services
{
    public class ArtistaService : IArtista
    {
        private readonly DiscografiaContext _context;

        public ArtistaService(DiscografiaContext context)
        {
            _context = context;
        }

        public async Task<IResult> Create(Artista artista)
        {
            _context.Artistas.Add(artista);
            await _context.SaveChangesAsync();
            return TypedResults.Created($"/Artista/{artista.ArtistaId}");
        }

        public async Task<IResult> Delete(int id)
        {
            if (await _context.Artistas.FindAsync(id) is Artista artista)
            {
                _context.Artistas.Remove(artista);
                await _context.SaveChangesAsync();
                return TypedResults.Ok(artista);
            }
            return TypedResults.NotFound();
        }

        public async Task<IResult> Get(int id)
        {
            return await _context.Artistas.FirstOrDefaultAsync(p => p.ArtistaId == id)
                is Artista artista
                ? TypedResults.Ok(artista)
                : TypedResults.NotFound();
        }

        public async Task<IResult> GetAll()
        {
            return TypedResults.Ok(await _context.Artistas.ToArrayAsync() );

        }
    }
}
