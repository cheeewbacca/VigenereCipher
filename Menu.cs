using System;
namespace Vigenere
{
    static class Menu
    {
        static event MessageHandler ShowMessage;
        static Menu() => ShowMessage += Display;
        public static void ChooseProcedure()
        {
            string procedure = null;
            while (procedure != "exit")
            {
                ShowMessage.Invoke("--> Choose encryption or decryption <--");
                ShowMessage.Invoke("--> Enter exit to stop the program");
                procedure = Console.ReadLine();
                DataProcessing(procedure);
            }
        }
        static void DataProcessing(string procedure)
        {
            string text = null, key = null;
            switch (procedure)
            {
                case "encryption":
                    GetText(ref text, ref key);
                    VigenereEncryptionService encryptedMessage = new VigenereEncryptionService(text);
                    ShowMessage.Invoke("*** Encrypted text ***");
                    encryptedMessage.MessageEncrypt(key);
                    break;
                case "decryption":
                    GetText(ref text, ref key);
                    VigenereDecryptionService decryptedMessage = new VigenereDecryptionService(text);
                    ShowMessage.Invoke("*** Deccrypted text ***");
                    decryptedMessage.MessageDecrypt(key);
                    break;
                case "exit":
                    ShowMessage.Invoke("Have a nice day!");
                    break;
                default:
                    ShowMessage.Invoke("There`s no suitable operation");
                    break;
            }
        }
        static void GetText(ref string text, ref string key)
        {
            ShowMessage.Invoke("--> Enter your text to process <--");
            text = Console.ReadLine();
            ShowMessage.Invoke("--> Enter your key <--");
            key = Console.ReadLine();
        }
        static void Display(string message) => Console.WriteLine(message);
    }
}
