namespace Vigenere
{
    class VigenereDecryptionService : IDecryptionService
    {
        string Message { get; set; }
        public VigenereDecryptionService(string message) => Message = message;

        public void MessageDecrypt(string key)
        {
            if (VigenereProcedureService.KeyCheck(key))
            {
                char[] decryptedSymbols = new char[Message.Length];
                for (int i = 0, j = 0, n = Message.Length; i < n; i++)
                {
                    if (!char.IsLetter(Message[i]))
                        decryptedSymbols[i] = Message[i];
                    else
                    {
                        int asciiOffset = char.IsUpper(Message[i]) ? 65 : 97;
                        int ci = Message[i] - asciiOffset;
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
