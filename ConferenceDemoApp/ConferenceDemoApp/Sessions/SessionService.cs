using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ConferenceDemoApp.Sessions
{
    public class SessionService : ISessionService
    {

        private readonly HttpClient _client;
        private IList<Session> _sessions;


        public SessionService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://my-json-server.typicode.com/AndreKraemer/ConferenceAppDemoData/");
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IList<Session>> GetSessionsAsync()
        {
            return await GetSessionsInternalAsync(false);
        }

        private async Task<IList<Session>> GetSessionsInternalAsync(bool useCached)
        {
            if (IsConnected && (!useCached || _sessions == null || !_sessions.Any() ))
            {
                var json = await _client.GetStringAsync($"sessions");
                _sessions = JsonConvert.DeserializeObject<IList<Session>>(json);
            }

            return _sessions;
        }

        public async Task<IList<Session>> GetFavoritesAsync()
        {
            return (await GetSessionsInternalAsync(true)).Where(x => x.IsFavorite).ToList();

        }

        public async Task<IList<Session>> Search(string filter)
        {
            return (await GetSessionsInternalAsync(true)).Where(x => x.Title.ToLower().Contains(filter.ToLower())).ToList();
        }

        public async Task<Session> GetSessionAsync(int id)
        {
            return (await GetSessionsInternalAsync(true)).SingleOrDefault(x => x.Id == id);
        }
    }
}