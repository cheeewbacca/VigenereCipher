using System;
namespace Vigenere
{
    static class Menu
    {
        delegate void MessageHandler(string message);
        static event MessageHandler ShowMessage;
        static Menu() => ShowMessage += Display; 
        public static void ChooseProcedure()
        {
            ShowMessage.Invoke("--> Choose encryption(0) or decryption(1) <--");
            int procedure = Convert.ToInt32(Console.ReadLine());
            ShowMessage.Invoke("--> Enter your text to process <--");
            string text = Console.ReadLine();
            ShowMessage.Invoke("--> Enter tour key <--");
            string key = Console.ReadLine();
            DataProcessing(procedure, text, key);
        }
        static void DataProcessing(int procedure, string text, string key)
        {
            switch(procedure)
            { 
                case 0:
                    VigenereEncryptionService encryptedMessage = new VigenereEncryptionService(text);
                    ShowMessage.Invoke("*** Encrypted text ***");
                    encryptedMessage.MessageEncrypt(key);
                    break;
                case 1:
                    VigenereDecryptionService decryptedMessage = new VigenereDecryptionService(text);
                    ShowMessage.Invoke("*** Deccrypted text ***");
                    decryptedMessage.MessageDecrypt(key);
                    break;
                default:
                    ShowMessage.Invoke("There`s no suitable operation");
                    break;
            }
        }
        static void Display(string message) => Console.WriteLine(message);
    }
}
