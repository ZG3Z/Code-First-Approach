using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class MusiciansController : ControllerBase
    {
        private readonly IMusicianService _service;

        public MusiciansController(IMusicianService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbum(int id)
        {
            if (!_service.AlbumExist(id).Result)
                return NotFound("The album not exists in the database");
           
            var info = await _service.GetAlbum(id);
            return Ok(info);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            if (!_service.MusicianExist(id).Result)
                return NotFound("The musician not exists in the database");

            if (!_service.AllTrackNotExistInAlbums(id).Result)
                return BadRequest("Cannot delete musician");

            await _service.DeleteMusician(id);
            return  Ok("Musician has been removed");
        }
    }
}