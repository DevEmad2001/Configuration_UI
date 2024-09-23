using GUI_Adtech.Models;

namespace GUI_Adtech.Repositories
{
    public interface IConfigRepository
    {
        Task<IEnumerable<AdtechConfig>> GetAllConfigsAsync();
        Task<AdtechConfig> GetConfigByIdAsync(int id);
        Task AddConfigAsync(AdtechConfig config);
        Task UpdateConfigAsync(AdtechConfig config);
        Task DeleteConfigAsync(int id);
    }
}
