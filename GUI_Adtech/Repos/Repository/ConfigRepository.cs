using System.Collections.Generic;
using System.Threading.Tasks;
using GUI_Adtech.Models;
using Microsoft.EntityFrameworkCore;

namespace GUI_Adtech.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdtechConfig>> GetAllConfigsAsync()
        {
            return await _context.Configs.ToListAsync();
        }

        public async Task<AdtechConfig> GetConfigByIdAsync(int id)
        {
            return await _context.Configs.FindAsync(id);
        }

        public async Task AddConfigAsync(AdtechConfig config)
        {
            _context.Configs.Add(config); // إضافة البيانات إلى DbSet
            await _context.SaveChangesAsync(); // حفظ التغييرات
        }


        public async Task UpdateConfigAsync(AdtechConfig config)
        {
            _context.Configs.Update(config);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfigAsync(int id)
        {
            var config = await _context.Configs.FindAsync(id);
            if (config != null)
            {
                _context.Configs.Remove(config);
                await _context.SaveChangesAsync();
            }
        }
    }
}
