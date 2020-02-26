using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceDemoApp.Sessions
{
    public class DummySessionsService : ISessionService
    {


        public Task<IList<Session>> GetSessionsAsync()
        {
            IList<Session> sessions = new List<Session>
            {
                new Session
                {
                    Id = 1,
                    Title = "EF Core und Xamarin",
                    SpeakerId = 1,
                    Speaker = "Wilhelm Brause",
                    Description = "In diesem Vortrag lernen Sie, wie Sie das EF Core unter Xamarin nutzen.",
                    IsFavorite = true
                },
                new Session
                {
                    Id = 2,
                    Title = "Durchgänngige UIs mit Xamarin.Visuals",
                    SpeakerId = 2,
                    Speaker = "Hans Dampf",
                    Description = "Ein Einblick in Xamarin.Visuals",
                    IsFavorite = false
                },
                new Session
                {
                    Id = 3,
                    Title = "Sichere Datenhaltung in Xamarin Apps",
                    SpeakerId = 3,
                    Speaker = "Anna Gramm",
                    Description =
                        "Anna Gramm erklärt in diesem Vortrag, wie Sie Ihre Daten vor unberechtigten Zugriffen schützen.",
                    IsFavorite = true
                }
            };
            return Task.FromResult(sessions);
        }

        public async Task<Session> GetSessionAsync(int id)
        {
            return (await GetSessionsAsync()).SingleOrDefault(x => x.Id == id);
        }

        public async Task<IList<Session>> GetFavoritesAsync()
        {
            return (await GetSessionsAsync()).Where(x => x.IsFavorite).ToList();
        }

        public async Task<IList<Session>> Search(string filter)
        {
            return (await GetSessionsAsync()).Where(x => x.Title.ToLower().Contains(filter.ToLower())).ToList();
        }

    }
}