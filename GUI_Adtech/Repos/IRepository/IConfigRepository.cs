using GUI_Adtech.Models;
using Microsoft.EntityFrameworkCore;

namespace GUI_Adtech.Repositories
{
    public interface IConfigRepository
    {
        Task<IEnumerable<AdtechConfig>> GetAllConfigsAsync();
        Task<AdtechConfig> GetConfigByIdAsync(int id);

        public Task<AdtechConfig> GetConfigByParameterNameAsync(string parameterName);
        
        
        Task AddConfigAsync(AdtechConfig config);
        Task UpdateConfigAsync(AdtechConfig config);
        Task DeleteConfigAsync(int id);
    }
}
