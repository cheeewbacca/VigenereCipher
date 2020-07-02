namespace Vigenere
{
    interface IEncryptionService
    {
        void MessageEncrypt(string key, string message);
    }
}
