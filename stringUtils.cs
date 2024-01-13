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


        public static String ConvertDateToString(Date date)
        {
            int year = date.Year;

            int month = date.Month;

            int day = date.Day;

            String str_Date= year+"-"+month+"-"+day;


            return str_Date;
        }



        public static Date ConvertToDate(string dateString)
        {
            if (dateString == "" || dateString == null)
            {
                return null;
            }
            try
            {
                String data = "";

                int cnt = 0;
                int year = 0;
                int month = 0;

                int day = 0;
                for (int i = 0; i < dateString.Length; i++)
                {

                    if (dateString[i] == '-')
                    {
                        if (cnt == 0)
                        {
                            year = ConvertToInt(data); cnt++;
                            //Console.WriteLine(year);
                        }
                        else if (cnt == 1)
                        {
                            month = ConvertToInt(data); cnt++;
                            //Console.WriteLine(month);
                        }

                        data = "";
                    }
                    else
                    {
                        data += dateString[i];
                    }
                    //Console.WriteLine(data);
                }

                day = ConvertToInt(data);

                return new Date(year, month, day);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
