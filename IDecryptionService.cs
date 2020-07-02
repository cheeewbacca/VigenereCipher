namespace Vigenere
{
    interface IDecryptionService
    {
        void MessageDecrypt(string key, string message);
    }
}
