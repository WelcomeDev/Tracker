namespace SingleServiceApp.Providers.Auth.Security
{
    public interface IEncryptionAlgorithm
    {
        public byte[] Key { get; set; }
        public string Encryption(string closeText);
        public string Decryption(string openText);
    }
}
