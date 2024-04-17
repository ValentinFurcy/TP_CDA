using DTOs.ThemeDTOs;
using IRepositories;
using IServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ThemeService : IThemeService
    {
        IThemeRepository _themeRepository;
        public ThemeService(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }
        public async Task<Theme> CreateThemeAsync(ThemeDTO themeDTO)
        {
            Theme theme = new Theme { Label = themeDTO.Label };

            return await _themeRepository.CreateThemeAsync(theme);
        }

        public async Task<bool> DeleteThemeAsync(int themeId)
        {
            return await _themeRepository.DeleteThemeAsync(themeId);
        }

        public async Task<List<Theme>> GetAllThemeAsync()
        {
           return await _themeRepository.GetAllThemeAsync();
        }

        public async Task<Theme> GetThemeByIdAsync(int themeId)
        {
            return await _themeRepository.GetThemeByIdAsync(themeId);
        }

        public async Task<Theme> UpdateThemeAsync(ThemeUpdateDTO themeUpdateDTO)
        {
            Theme theme = new Theme { Id = themeUpdateDTO.Id, Label = themeUpdateDTO.Label };

            return await _themeRepository.UpdateThemeAsync(theme);
        }

    }
}
