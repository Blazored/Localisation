using System.Threading.Tasks;

namespace Blazored.Localisation.Services
{
    public interface IBrowserDateTimeProvider
    {
        Task<IBrowserDateTime> GetInstance();
    }
}