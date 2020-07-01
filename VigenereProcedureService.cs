using System;
using System.Linq;
namespace Vigenere
{
    delegate void MessageHandler(string message);
    static class VigenereProcedureService
    {
        static event MessageHandler ShowMessage;
        public static bool KeyCheck(string key)
        {
            if (!key.All(char.IsLetter))
                return false;
            return true;
        }
        static bool checkSubscription = false;
        static void DisplayMessage(string message) => Console.WriteLine(message);
        public static void InvokeMessage(string message)
        {
            if (!checkSubscription)
            {
                ShowMessage += DisplayMessage;
                checkSubscription = true;
            }
            ShowMessage.Invoke(message);
        }
    }
}
