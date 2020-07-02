namespace Vigenere
{
    class VigenereEncryptionService : IEncryptionService
    {
        public void MessageEncrypt(string key, string message)
        {
            if (VigenereProcedureService.KeyCheck(key))
            {
                char[] encryptedSymbols = new char[message.Length];
                for (int i = 0, j = 0, n = message.Length; i < n; i++)
                {
                    if (!char.IsLetter(message[i]))
                        encryptedSymbols[i] = message[i];
                    else
                    {
                        int asciiOffset = char.IsUpper(message[i]) ? 65 : 97;
                        int pi = message[i] - asciiOffset;
                        int kj = char.ToUpper(key[j % key.Length]) - 65;
                        int ci = (pi + kj) % 26;
                        j++;
                        encryptedSymbols[i] = (char)(ci + asciiOffset);
                    }
                }
                string encryptedMessage = new string(encryptedSymbols);
                VigenereProcedureService.InvokeMessage(encryptedMessage);
            }
        }
    }
}
