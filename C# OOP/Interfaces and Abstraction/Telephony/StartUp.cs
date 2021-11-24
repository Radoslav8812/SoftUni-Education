using System;
using System.Linq;
using System.Collections.Generic;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var splitedPhoneNumbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var splitedWeb = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var phone = new SmartPhone();

            for (int i = 0; i < splitedPhoneNumbers.Length; i++)
            {
                Console.WriteLine(phone.Call(splitedPhoneNumbers[i]));
            }

            for (int i = 0; i < splitedWeb.Length; i++)
            {
                Console.WriteLine(phone.Browse(splitedWeb[i]));
            }
        }
    }
}
