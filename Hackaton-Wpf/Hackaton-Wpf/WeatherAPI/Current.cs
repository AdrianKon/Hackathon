using System;
using System.Globalization;

namespace Hackaton_Wpf.WeatherAPI
{
    class Current
    {
        public string Summary { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }

        public void TemperatureToCelcius()
        {
            double.TryParse(Temperature, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out var doubeTemperature);
            doubeTemperature = (doubeTemperature - 32.0) / 1.8;
            doubeTemperature = Math.Truncate(100 * doubeTemperature) / 100;
            Temperature = doubeTemperature.ToString(CultureInfo.CurrentCulture);
        }
    }
}