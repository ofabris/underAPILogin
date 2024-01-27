using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text.RegularExpressions;
using UnderAPILogin.Data;
using UnderAPILogin.Models;

namespace UnderAPILogin.Repositories
{
    public class InsertMusicRepository : IInsertMusicRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InsertMusicRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertMusic(Music music)
        {
            if (string.IsNullOrEmpty(music.Link))
            {
                throw new Exception("Preencha o link da música");
            }

            try
            {
                string plataformMusic = ValidPlataform(music.Link);

                string linkToInsert = "";
                
                switch (plataformMusic)
                {
                    case "spotify":
                        string urlChangeSpotify = ExtractLinkSpotify(music.Link);

                        Console.WriteLine(urlChangeSpotify);

                        linkToInsert = $"https://open.spotify.com/embed/track/{urlChangeSpotify}?";
                        break;
                    case "soundcloud":

                        linkToInsert = $"https://w.soundcloud.com/player/?url={music.Link}";
                        break;
                    default:
                        Console.WriteLine("Plataforma não reconhecida");
                        break;
                }

                _dbContext.Music.Add(music);

                _dbContext.SaveChanges();

            }
            catch (Exception)
            {
                Console.WriteLine($"Erro ao inserir música");
                throw;
            }
        }

        public string ValidPlataform(string link)
        {
            switch (link)
            {
                case string l when l.Contains("spotify"):
                    return "spotify";
                case string l when l.Contains("soundcloud"):
                    return "soundcloud";
                default:
                    return "Plataforma não reconhecida";
            }
        }

        static string ExtractLinkSpotify(string link)
        {
            string padrao = @"/track/([a-zA-Z0-9]+)";

            Match correspondencia = Regex.Match(link, padrao);

            if (correspondencia.Success)
            {
                return correspondencia.Groups[1].Value;
            }
            return null;
        }
    }
}