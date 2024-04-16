using IRepositories;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        WikyDbContext _context;

        public ThemeRepository(WikyDbContext wikyDbContext)
        {
            _context = wikyDbContext;
        }
        public async Task<Theme> CreateThemeAsync(Theme theme)
        {
            try
            {
                _context.Themes.Add(theme);
                await _context.SaveChangesAsync();
                return theme;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<bool> DeleteThemeAsync(int themeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Theme>> GetAllThemeAsync()
        {
            var themes = await _context.Themes.ToListAsync();
            if (themes.Any())
            {
                return themes;
            }
            else throw new Exception("Aucun theme trouvé");
        }

        public async Task<Theme> GetThemeByIdAsync(int themeId)
        {
            var theme = await _context.Themes.FindAsync(themeId);
            if (theme != null)
            {
                return theme;
            }
            else throw new Exception("Aucun theme trouvé");
        }

        public async Task<Theme> UpdateThemeAsync(Theme theme)
        {
            try
            {
                var nbRows = await _context.Themes.Where(t => t.Id == theme.Id).ExecuteUpdateAsync(
                    updates => updates.SetProperty(t => t.Label, theme.Label)                         
                    );
                if (nbRows > 0)
                {
                    return theme;
                }
                throw new Exception("La modification a échouée");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
