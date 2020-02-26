using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ConferenceDemoApp.Speakers
{
    public class SpeakerService : ISpeakerService
    {

        private readonly HttpClient _client;
        private IList<Speaker> _speakers;


        public SpeakerService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://my-json-server.typicode.com/AndreKraemer/ConferenceAppDemoData/");
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IList<Speaker>> GetSpeakersAsync()
        {
            if (IsConnected)
            {
                var json = await _client.GetStringAsync($"speakers");
                _speakers  = JsonConvert.DeserializeObject<IList<Speaker>>(json);
            }

            return _speakers;
        }

        public async Task<IList<Speaker>> Search(string filter)
        {
            return (await GetSpeakersAsync()).Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();
        }

        public async Task<Speaker> GetSpeakerAsync(int id)
        {
            return (await GetSpeakersAsync()).SingleOrDefault(x => x.Id == id);
        }
    }
}