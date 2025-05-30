﻿using System.Globalization;

namespace SchoolApp.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        public string Localize(string textAr, string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEn;

        }
    }
}
