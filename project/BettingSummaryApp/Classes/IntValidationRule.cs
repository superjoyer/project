using System;
using System.Globalization;
using System.Windows.Controls;

namespace BettingSummaryApp.Classes
{
    class IntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int intVal = 0;
            bool canConvert = false;
            string strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Поле не может быть пустым!");

            if (strValue != "")
            {
               
                try
                {
                   canConvert =  Int32.TryParse(strValue, out intVal);
                    if (intVal <= 0)
                        return new ValidationResult(false, $"Невалидные даныные");
                }
                catch
                {
                    throw new Exception("Please Enter Date in DD/MM/YYYY format");
                }
            }
            return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Поле должно быть числом!");
        }
    }
}
