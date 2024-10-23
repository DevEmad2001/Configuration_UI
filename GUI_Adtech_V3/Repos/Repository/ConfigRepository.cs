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

        /// <summary>
        /// 
        /// </summary>.
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public async Task<AdtechConfig> GetConfigByParameterNameAsync(string parameterName) // DataBase (Core)
        {
            return await _context.Configs.FirstOrDefaultAsync(c => c.ParameterName == parameterName);
        }
        public async Task<AdtechConfig> GetConfigByParameterAndComponentAsync(string parameterName, string componentName) //Folder Structer Code (Core) 
        {
            return await _context.Configs.FirstOrDefaultAsync(c => c.ParameterName == parameterName && c.ComponentName == componentName);
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
            _context.Add(config); // إضافة البيانات إلى DbSet
            await _context.SaveChangesAsync(); // حفظ التغييرات
        }


        public async Task UpdateConfigAsync(AdtechConfig config)
        {
            _context.Update(config);

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
