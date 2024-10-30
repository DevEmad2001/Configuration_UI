using System.Threading.Tasks;
using GUI_Adtech.Models;
using Microsoft.EntityFrameworkCore;


namespace GUI_Adtech.Repositories
{
    public class AuthConfigRepository : IAuthConfigRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthConfigRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<AdtechConfig> GetConfigAsync(string parameterName, string componentName)
        {
            return await _context.Configs
                .FirstOrDefaultAsync(c => c.ParameterName == parameterName && c.ComponentName == componentName);
        }

        public async Task UpdateConfigAsync(AdtechConfig config)
        {
            _context.Configs.Update(config);
            await _context.SaveChangesAsync();
        }

        public async Task AddConfigAsync(AdtechConfig config)
        {
            _context.Configs.Add(config);
            await _context.SaveChangesAsync();
        }



        // دوال المصادقة
        public async Task<AdtechConfig> GetBasicAuthConfig(string componentName)
        {
            return await GetConfigAsync("Authentication", componentName);
        }

        public async Task<AdtechConfig> GetTokenAuthConfig(string componentName)
        {
            return await GetConfigAsync("Token", componentName);
        }

        public async Task<AdtechConfig> GetCertificateAuthConfig(string componentName)
        {
            return await GetConfigAsync("CertificatePath", componentName);
        }
    }
}
