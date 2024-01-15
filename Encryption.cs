using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public static class Encryption
    {
        private static Queue<int> keyQueue = new Queue<int>();




        private static void initialize()
        {
            keyQueue.Clear();
            keyQueue.Enqueue(3);
            keyQueue.Enqueue(1);
            keyQueue.Enqueue(7);
            keyQueue.Enqueue(5);
        }

        public static string EncryptPassword(string password)
        {
            initialize();
            string encodedPass = "";

            foreach (char c in password)
            {
                int shift = keyQueue.Dequeue();
                keyQueue.Enqueue(shift);

                char encodedChar = (char)(c + shift);
                encodedPass += encodedChar;
            }

            return encodedPass;
        }
    }
}
