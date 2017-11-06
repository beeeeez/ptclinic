using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace PTClinic
{
    class Validation
    {
        public static bool IsValidEmail(string email)
        {
            System.Text.RegularExpressions.Regex emailRegex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            System.Text.RegularExpressions.Match emailMatch = emailRegex.Match(email);
            return emailMatch.Success;
        }

        public static bool IsValidUserLength(string username)
        {
            return username.Length > 3;
        }


        //Validating that the length is greater than 0
        static public bool IsItFilledIn(string temp)
        {
            bool result = false;

            if (temp.Length > 0)
            {
                result = true;
            }

            return result;
        }

        //Validating that the length is greater than or equal to the minimum length set
        static public bool IsItFilledIn(string temp, int minlen)
        {
            bool result = false;

            if (temp.Length >= minlen)
            {
                result = true;
            }
            return result;
        }

        //Validating that the string length is between the minimum and maximum lengths allowed
        static public bool IsWithinRange(string temp, int minlength, int maxlength)
        {
            bool result = false;

            if (temp.Length != minlength && temp.Length != maxlength)
            {
                result = true;
            }
            return result;
        }

        //Validating that the integer length is between the minimum and maximum lengths allowed
        static public bool IsWithinRange(int temp, int minlength, int maxlength)
        {
            bool result = false;

            if (temp < minlength || temp > maxlength)
            {
                result = true;
            }
            return result;
        }

        //Validating that a selected start date is before the selected end date
        static public bool IsValidStartDate(DateTime temp, DateTime start)
        {
            bool result = false;

            if (temp > start)
            {
                result = true;
            }
            return result;
        }

        //Validating the Length based on just a maximum length
        static public bool IsValidLength(string temp, int maxlen)
        {
            bool result = false;

            if (temp.Length < maxlen || temp.Length > maxlen)
            {
                result = true;
            }

            return result;
        }

        //Validating the Length based on minimum and maximum length
        static public bool IsValidLength(string temp, int minlen, int maxlen)
        {
            bool result = false;

            if (temp.Length < minlen || temp.Length > maxlen)
            {
                result = true;
            }

            return result;
        }


    }
}
