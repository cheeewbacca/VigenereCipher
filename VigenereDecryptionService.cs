namespace Vigenere
{
    class VigenereDecryptionService : IDecryptionService
    {
        public void MessageDecrypt(string key, string message)
        {
            if (VigenereProcedureService.KeyCheck(key))
            {
                char[] decryptedSymbols = new char[message.Length];
                for (int i = 0, j = 0, n = message.Length; i < n; i++)
                {
                    if (!char.IsLetter(message[i]))
                        decryptedSymbols[i] = message[i];
                    else
                    {
                        int asciiOffset = char.IsUpper(message[i]) ? 65 : 97;
                        int ci = message[i] - asciiOffset;
                        int kj = char.ToUpper(key[j % key.Length]) - 65;
                        int pi = (ci - kj) % 26;
                        j++;
                        decryptedSymbols[i] = (char)(pi + asciiOffset);
                    }
                }
                string decryptedMessage = new string(decryptedSymbols);
                VigenereProcedureService.InvokeMessage(decryptedMessage);
            }
        }
    }
}
