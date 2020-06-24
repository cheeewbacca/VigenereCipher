using System;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            VigenereEncryptionService mess = new VigenereEncryptionService("HELLO");
            mess.MessageEncrypt("ABC");
            Console.ReadKey();
        }
    }
}
