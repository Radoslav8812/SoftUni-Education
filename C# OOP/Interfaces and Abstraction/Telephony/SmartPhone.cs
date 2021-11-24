using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class SmartPhone : IBrowserable, ICallable
    {
        public string Browse(string webAdress)
        {
            if (IsBrowseValid(webAdress))
            {
                return $"Browsing: {webAdress}!";
            }
            return "Invalid URL!";
        }
        bool IsBrowseValid(string webSite)
        {
            bool isValid = true;
            for (int i = 0; i < webSite.Length; i++)
            {
                if (char.IsDigit(webSite[i]))
                {
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }

        public string Call(string number)
        {

            if (NumberValidation(number))
            {
                if (number.Length > 7)
                {
                    return $"Calling... {number}";
                }
                else
                {
                    return $"Dialing... {number}";
                }
            }
            return "Invalid number!";
        }
        bool NumberValidation(string number)
        {
            var isValid = true;
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }
    }
}


