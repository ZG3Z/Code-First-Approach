using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IMusicianService
    {
        public  Task<bool> AlbumExist(int id);
        public  Task<AlbumDto> GetAlbum(int id);
        public  Task<bool> MusicianExist(int id);
        public Task<bool> AllTrackNotExistInAlbums(int id);
        public Task DeleteMusician(int id);
    }
}