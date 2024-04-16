using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IThemeRepository
    {
        Task<Theme> CreateThemeAsync(Theme theme);
        Task<List<Theme>> GetAllThemeAsync();
        Task<Theme> GetThemeByIdAsync(int themeId);
        Task<Theme> UpdateThemeAsync(Theme theme);
        Task<bool> DeleteThemeAsync(int themeId);
    }
}
