namespace Vigenere
{
    class VigenereEncryptionService : IEncryptionService
    {
        string Message { get; set; }
        public VigenereEncryptionService(string message) => Message = message;

        public void MessageEncrypt(string key)
        {
            if (VigenereProcedureService.KeyCheck(key))
            {
                char[] encryptedSymbols = new char[Message.Length];
                for (int i = 0, j = 0, n = Message.Length; i < n; i++)
                {
                    if (!char.IsLetter(Message[i]))
                        encryptedSymbols[i] = Message[i];
                    else
                    {
                        int asciiOffset = char.IsUpper(Message[i]) ? 65 : 97;
                        int pi = Message[i] - asciiOffset;
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
