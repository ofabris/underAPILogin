using UnderAPILogin.Models;
using UnderAPILogin.Repositories;

namespace UnderAPILogin.Services
{
    public class InsertMusicService : IInsertMusicService
    {
        private readonly IInsertMusicRepository _insertMusicRepository;

        public InsertMusicService(IInsertMusicRepository insertMusicRepository)
        {
            _insertMusicRepository = insertMusicRepository;
        }

        public void InsertMusic(Music music)
        {
            _insertMusicRepository.InsertMusic(music);

            return;
        }
    }
}