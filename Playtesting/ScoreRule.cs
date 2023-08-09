using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Playtesting
{
    public class ScoreRule : ValidationRule
    {
        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            byte score;
            try
            {
                score = Convert.ToByte(value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false,"Adatszerkesztés sikertelen! Hiba: " + e.Message);
            }

            if (score is < 1 or > 10)
                return new ValidationResult(false,
                    "Adatszerkesztés sikertelen! A beírt értéknek 1-10 között kell lennie.");
            return ValidationResult.ValidResult;
        }
    }
}