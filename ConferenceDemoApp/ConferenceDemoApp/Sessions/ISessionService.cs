using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceDemoApp.Sessions
{
    public interface ISessionService
    {
        Task<IList<Session>> GetSessionsAsync();
        Task<Session> GetSessionAsync(int id);
        Task<IList<Session>> GetFavoritesAsync();

        Task<IList<Session>> Search(string filter);
    }
}
