using GUI_Adtech.Models;
using Microsoft.EntityFrameworkCore;

namespace GUI_Adtech.Repositories
{
    public interface IConfigRepository
    {
        Task<IEnumerable<AdtechConfig>> GetAllConfigsAsync();
        Task<AdtechConfig> GetConfigByIdAsync(int id);

        public Task<AdtechConfig> GetConfigByParameterNameAsync(string parameterName); // Database core
        public Task<AdtechConfig> GetConfigByParameterAndComponentAsync(string parameterName, string componentName); //Folder Structer Core


       Task AddConfigAsync(AdtechConfig config);
        Task UpdateConfigAsync(AdtechConfig config);
        Task DeleteConfigAsync(int id);

        //add for Auth
        Task UpdateOrInsertConfigAsync(string parameterName, string parameterValue, string componentName);
        Task SetNullIfExistsAsync(string parameterName, string componentName);


        
    }
}
