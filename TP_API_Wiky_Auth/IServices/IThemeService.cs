using DTOs;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IThemeService
    {
        Task<Theme> CreateThemeAsync(ThemeDTO themeDTO);
        Task<List<Theme>> GetAllThemeAsync();
        Task<Theme> GetThemeByIdAsync(int themeId);
        Task<bool> DeleteThemeAsync(int themeId);
        Task<Theme> UpdateThemeAsync(ThemeUpdateDTO themeUpdateDTO);
    }
}
