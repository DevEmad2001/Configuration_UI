using GUI_Adtech_V2.Models.Sys;

namespace GUI_Adtech_V2.Repos.IRepository
{
    public interface IConfigRepository
    {
        Task<IEnumerable<AdtechConfig>> GetAllConfigsAsync();
        Task<AdtechConfig> GetConfigByIdAsync(int id);
        Task<AdtechConfig> GetConfigByParameterNameAsync(string parameterName); // Database core
        Task<AdtechConfig> GetConfigByParameterAndComponentAsync(string parameterName, string componentName); //Folder Structure Core
        Task AddConfigAsync(AdtechConfig config);
        Task UpdateConfigAsync(AdtechConfig config);
        Task DeleteConfigAsync(int id);
    }
}
