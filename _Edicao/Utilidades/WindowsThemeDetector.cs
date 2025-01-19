using Microsoft.Win32;
using static Microsoft.Win32.SystemEvents;
using System;
using Windows.UI.ViewManagement;

namespace Summarizer
{
    public static class DarkModeHelper
    {
        public static bool IsDarkModeEnabled()
        {
            return CheckIsDarkModeEnabled();
        }

        private static bool CheckIsDarkModeEnabled()
        {
            var registryValue = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", null);

            if (registryValue != null && registryValue is int intValue)
            {
                return intValue == 0;
            }

            var uiSettings = new UISettings();
            var foreground = uiSettings.GetColorValue(UIColorType.Foreground);
            var isLightForeground = IsColorLight(foreground);

            return !isLightForeground;
        }

        private static bool IsColorLight(Windows.UI.Color color)
        {
            // Calcula o valor de luminância do ciano, magenta e amarelo (CMY) da cor fornecida
            var cmy = new float[] { 1 - color.R / 255f, 1 - color.G / 255f, 1 - color.B / 255f };
            var luminance = 0.2126f * cmy[0] + 0.7152f * cmy[1] + 0.0722f * cmy[2];
            // Se o valor de luminância for menor que 0,5, a cor é considerada clara
            return luminance < 0.5f;
        }
    }
}
