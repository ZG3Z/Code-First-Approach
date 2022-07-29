using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly DbMusicContext _context;

            public MusicianService(DbMusicContext context)
            {
                _context = context;
            }

            public async Task<bool> AlbumExist(int id)
            {
                var count = await _context.Albums.Where(c => c.IdAlbum.Equals(id)).CountAsync();
                return count > 0;
            }

            public async Task<AlbumDto> GetAlbum(int id)
            {
                var album = _context.Albums.First(a => a.IdAlbum.Equals(id));
            
                return await Task.FromResult(new AlbumDto()
                {
                    AlbumName = album.AlbumName,
                    PublishDate = album.PublishDate,
                    MusicTrack = await _context.Tracks.Join(_context.Albums, t => t.IdMusicAlbum,
                            a => a.IdAlbum, (t, a) => new 
                            {
                                a.IdAlbum,
                                t.TrackName,
                                t.Duration
                            })
                        .Where(item => item.IdAlbum.Equals(album.IdAlbum))
                        .OrderBy(item => item.Duration)
                        .Select(item => new MusicTrackDto()
                        {
                            Name = item.TrackName
                        })
                        .ToListAsync()
            });

            }

           
            public async Task<bool> MusicianExist(int id)
            {
                var count = await _context.Musicians.Where(c => c.IdMusician.Equals(id)).CountAsync();
                return count > 0;
            }

            public async Task<bool> AllTrackNotExistInAlbums(int id)
            {
                return await _context.MusicianTracks
                    .Where(mt => mt.IdMusician.Equals(id))
                    .Join(_context.Tracks, mt => mt.IdTrack, t => t.IdTrack,
                        ((mt, t) => new
                        {
                            t.Album,
                            mt.IdTrack
                        }))
                    .AllAsync(item => item.Album.Equals(null));
            }

            public async Task DeleteMusician(int id)
            {
                await using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var musician = await _context.Musicians.FirstAsync(musician => musician.IdMusician.Equals(id));

                        _context.Musicians.Remove(musician);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();	
                    }
                }
            }
    }
}