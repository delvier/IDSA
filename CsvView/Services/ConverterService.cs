using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Services
{
    public class ConverterService
    {
        public string ConvertToLatin(string value)
        {
            value = value.Replace("&oacute;", "ó");
            char[] normalizedArray = new char[value.Length];
            int i = 0;

            foreach (var item in value.ToCharArray())
            {
                normalizedArray[i++] = normalizeChar(item);
            }
            return new string(normalizedArray);
        }

        private char normalizeChar(char c)
        {
            switch (c)
            {
                case 'ą':
                    return 'a';
                case 'ć':
                    return 'c';
                case 'ę':
                    return 'e';
                case 'ł':
                    return 'l';
                case 'ń':
                    return 'n';
                case 'ó':
                    return 'o';
                case 'ś':
                    return 's';
                case 'ż':
                case 'ź':
                    return 'z';
            }
            return c;
        }
    }
}
