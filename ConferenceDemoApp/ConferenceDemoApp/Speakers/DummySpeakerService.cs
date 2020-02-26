using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceDemoApp.Speakers
{
    public class DummySpeakerService : ISpeakerService
    {
        public Task<IList<Speaker>> GetSpeakersAsync()
        {
            IList<Speaker> speakers = new List<Speaker> {
            new Speaker
            {
                Id = 1,
                Name = "Wilhelm Brause",
                Company = "Software-Brause GmbH",
                Bio = "Wilhelm Brause ist Senior Developer bei der Software Brause GmbH."
            },
            new Speaker
            {
                Id = 2,
                Name = "Hans Dampf",
                Company = "SteamBytes Gbr",
                Bio = "Hans Dampf ist Junior Developer bei der SteamBytes Gbr."
            },
            new Speaker
            {
                Id = 3,
                Name = "Anna Gramm",
                Company = "CryptoBytes AG",
                Bio = "Anna Gramm ist Security-Spezialist  bei der CryptoBytes AG."
            }

            };
            return Task.FromResult(speakers);
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