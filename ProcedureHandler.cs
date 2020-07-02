using System;

namespace Vigenere
{
    static class ProcedureHandler
    {
        static event MessageHandler ShowMessage;
        static ProcedureHandler() => ShowMessage += Display;
        public static void ChooseProcedure()
        {
            string procedure = null;
            while (procedure != "exit")
            {
                ShowMessage.Invoke("--> Choose encryption or decryption");
                ShowMessage.Invoke("Enter exit to stop the program");
                procedure = Console.ReadLine();
                DataProcessing(procedure);
            }
        }
        static void DataProcessing(string procedure)
        {
            switch (procedure)
            {
                case "encryption":
                    Encryption(new VigenereEncryptionService());
                    break;
                case "decryption":
                    Decryption(new VigenereDecryptionService());
                    break;
                case "exit":
                    ShowMessage.Invoke("Bye");
                    break;
                default:
                    ShowMessage.Invoke("There`s no suitable operation");
                    break;
            }
        }
        static public void Encryption(IEncryptionService encryption)
        {
            string text = null, key = null;
            GetText(ref text, ref key);
            ShowMessage.Invoke("Encrypted text");
            encryption.MessageEncrypt(key, text);
        }
        static public void Decryption(IDecryptionService decryption)
        {
            string text = null, key = null;
            GetText(ref text, ref key); ShowMessage.Invoke("Deccrypted text");
            decryption.MessageDecrypt(key, text);
        }
        static void GetText(ref string text, ref string key)
        {
            ShowMessage.Invoke("--> Enter your text to process");
            text = Console.ReadLine();
            ShowMessage.Invoke("--> Enter your key");
            key = Console.ReadLine();
        }
        static void Display(string message) => Console.WriteLine(message);

    }
}
