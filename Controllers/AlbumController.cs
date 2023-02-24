using DataBaseFirstAPI.Models;
using DataBaseFirstAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseFirstAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        public readonly IAlbum _IAlbums;

        public AlbumController(IAlbum i_albums)
        {
            _IAlbums = i_albums;
        }

        [HttpGet]
        public async Task<IResult> Get() => await _IAlbums.GetAll();

        [HttpGet("{id}")]
        public async Task<IResult> GetById(int id) => await _IAlbums.Get(id);          
        [HttpPost]
        public async Task<IResult> Create(Album album) => await _IAlbums.Create(album);

        [HttpDelete]
        public async Task<IResult> Delete(int id) => await _IAlbums.Delete(id);
        
    }
}
