using DataBaseFirstAPI.Models;
using DataBaseFirstAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseFirstAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        public readonly IArtista _IArtista;

        public ArtistaController(IArtista I_Artista)
        {
            _IArtista = I_Artista;
        }

        [HttpGet]
        public async Task<IResult> Get() => await _IArtista.GetAll();

        [HttpGet("{id}")]
        public async Task<IResult> GetById(int id) => await _IArtista.Get(id);
        
        [HttpPost]
        public async Task<IResult> Create(Artista artista) => await _IArtista.Create(artista);
        
        [HttpDelete]
        public async Task<IResult> Delete(int id) => await _IArtista.Delete(id);
        

    }
}
