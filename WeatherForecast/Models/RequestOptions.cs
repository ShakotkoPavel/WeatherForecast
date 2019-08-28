using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class RequestOptions
    {
        private short _period;

        public string City { get; set; } = "New York";

        public string Unit { get; set; } = "imperial";

        public string Language { get; set; } = "en";

        public short Period
        {
            get { return _period; }

            set {
                if (value <= 5 || value >= 1)
                {
                    _period = value;
                }
                else
                {
                    _period = 5;
                }
            }
        }

        public RequestOptions()
        {
            //City = "New York";
            //Unit = Units.Fahrenheit;
            //Language = Languages.English;
            //Period = 5;
        }

        public RequestOptions(string city, Units unit, Languages language, short period)
        {
            City = city;
            Unit = OptionsDictionaries.GetUnit(unit);
            Language = OptionsDictionaries.GetLanguage(language);
            Period = period;
        }
    }

    public static class OptionsDictionaries
    {
        private static readonly Dictionary<Languages, string> _languages = new Dictionary<Languages, string>()
        {
            { Languages.Arabic,             "ar" },
            { Languages.Bulgarian,          "bg" },
            { Languages.Catalan,            "ca" },
            { Languages.Czech,              "cz" },
            { Languages.German,             "de" },
            { Languages.Greek,              "el" },
            { Languages.English,            "en" },
            { Languages.Persian,            "fa" },
            { Languages.Finnish,            "fi" },
            { Languages.French,             "fr" },
            { Languages.Galician,           "gl" },
            { Languages.Croatian,           "hr" },
            { Languages.Hungarian,          "hu" },
            { Languages.Italian,            "it" },
            { Languages.Japanese,           "ja" },
            { Languages.Korean,             "kr" },
            { Languages.Latvian,            "la" },
            { Languages.Lithuanian,         "lt" },
            { Languages.Macedonian,         "mk" },
            { Languages.Dutch,              "nl" },
            { Languages.Polish,             "pl" },
            { Languages.Portuguese,         "pt" },
            { Languages.Romanian,           "ro" },
            { Languages.Russian,            "ru" },
            { Languages.Swedish,            "se" },
            { Languages.Slovak,             "sk" },
            { Languages.Slovenian,          "sl" },
            { Languages.Spanish,            "es" },
            { Languages.Turkish,            "tr" },
            { Languages.Ukrainian,          "ua" },
            { Languages.Vietnamese,         "vi" },
            { Languages.Chinese_Simplified, "zh_cn" },
            { Languages.Chinese_Traditional,"zh_tw" }
        };

        private static readonly Dictionary<Units, string> _units = new Dictionary<Units, string>()
        {
            { Units.Fahrenheit, "imperial" },
            { Units.Celsius, "metric" },
            { Units.Kelvin, "standard" }
        };

        public static string GetLanguage(Languages language)
        {
            return _languages.GetValueOrDefault(language);
        }

        public static string GetUnit(Units unit)
        {
            return _units.GetValueOrDefault(unit);
        }
    }

    public enum Units
    {
        Kelvin,
        Celsius,
        Fahrenheit
    }

    public enum Languages
    {
        Arabic,
        Bulgarian,
        Catalan,
        Czech,
        German,
        Greek,
        English,
        Persian,
        Finnish,
        French,
        Galician,
        Croatian,
        Hungarian,
        Italian,
        Japanese,
        Korean,
        Latvian,
        Lithuanian,
        Macedonian,
        Dutch,
        Polish,
        Portuguese,
        Romanian,
        Russian,
        Swedish,
        Slovak,
        Slovenian,
        Spanish,
        Turkish,
        Ukrainian,
        Vietnamese,
        Chinese_Simplified,
        Chinese_Traditional
    }
}
