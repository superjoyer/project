using System;
using System.Globalization;
using System.Windows.Controls;

namespace BettingSummaryApp.Classes
{
    class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime dateVal;
            bool canConvert = false;
            string strValue = Convert.ToString(value);

             if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Поле не может быть пустым!");

             TransformToDate(strValue);

            if (strValue != "")
            {

                try
                {
                    canConvert = DateTime.TryParse(strValue, out dateVal);
                }
                catch
                {
                    throw new Exception("Введите дату в формате  DD/MM/YYYY");
                }
            }
            return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Поле должно быть числом!");
        }



        public object TransformToDate(string date)
        {
            if (date != null || date != "")
            {
                int day; int month; int year;
              //  date = value.ToString();
                try
                {
                    int.TryParse(date.Substring(0, 2), out day);
                    int.TryParse(date.Substring(3, 2), out month);
                    int.TryParse(date.Substring(6, 4), out year);
                    return new DateTime(year, month, day);
                }
                catch
                {
                    return new Exception("Please Enter Date in DD/MM/YYYY format");
                }
            }
            else
            {
                throw new Exception("Please Enter Date in DD/MM/YYYY format");
            }
        }
    }
}
