using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GUI_Adtech_V2.Data; // لمشروع ApplicationDbContext
using GUI_Adtech_V2.Models.Sys; // لمشروع AdtechConfig
using GUI_Adtech_V2.Repos.IRepository;



namespace GUI_Adtech_V2.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdtechConfig> GetConfigByParameterNameAsync(string parameterName)
        {
            return await _context.AdtechConfigs.FirstOrDefaultAsync(c => c.ParameterName == parameterName);
        }

        public async Task<AdtechConfig> GetConfigByParameterAndComponentAsync(string parameterName, string componentName)
        {
            return await _context.AdtechConfigs.FirstOrDefaultAsync(c => c.ParameterName == parameterName && c.ComponentName == componentName);
        }

        public async Task<IEnumerable<AdtechConfig>> GetAllConfigsAsync()
        {
            return await _context.AdtechConfigs.ToListAsync();
        }

        public async Task<AdtechConfig> GetConfigByIdAsync(int id)
        {
            return await _context.AdtechConfigs.FindAsync(id);
        }

        public async Task AddConfigAsync(AdtechConfig config)
        {
            _context.AdtechConfigs.Add(config);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateConfigAsync(AdtechConfig config)
        {
            _context.AdtechConfigs.Update(config);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfigAsync(int id)
        {
            var config = await _context.AdtechConfigs.FindAsync(id);
            if (config != null)
            {
                _context.AdtechConfigs.Remove(config);
                await _context.SaveChangesAsync();
            }
        }
    }

}

