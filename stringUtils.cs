using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class stringUtils
    {
        public static int ConvertToInt(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Input can't be null!");
            }

            int result = 0;
            bool isNegative = false;
            int i = 0;

            if (input[0] == '-')
            {
                isNegative = true;
                i = 1;
            }

            for (; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    throw new FormatException("Input string was not in a correct format!");
                }
                result = result * 10 + (input[i] - '0');
            }

            return isNegative ? -result : result;
        }

        public static double ConvertToDouble(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Input can't be null!");
            }

            int i = 0;
            int n = input.Length;
            double result = 0;
            double fraction = 1;
            bool isNegative = false;

            if (input[0] == '-')
            {
                isNegative = true;
                i = 1;
            }

            for (; i < n && input[i] != '.'; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    throw new FormatException("Input string was not in a correct format!");
                }
                result = result * 10 + (input[i] - '0');
            }

            if (i < n && input[i] == '.')
            {
                i++;
                for (; i < n; i++)
                {
                    if (input[i] < '0' || input[i] > '9')
                    {
                        throw new FormatException("Input string was not in a correct format!");
                    }
                    fraction *= 0.1;
                    result = result + (input[i] - '0') * fraction;
                }
            }

            return isNegative ? -result : result;
        }
    }
}
