using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public interface IInsertMusicRepository
    {
        void InsertMusic(Music music);
        string ValidPlataform(string link);
    }
}