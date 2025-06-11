namespace Cryptography
{
    public class Cryptography
    {
        private byte[] key { get { }; set { }; }

        private static byte[] GetBytes(string data) => System.Text.Encoding.UTF8.GetBytes(data);
        private static string GetString(byte[] data) => System.Text.Encoding.UTF8.GetString(data);
        private static byte[] Padding(byte[] data, int size)
        {
            byte[] result = new byte[size];
            for (int i = 0; i < size; i++)
                result[i] = data[i % size];
            return result;
        }

        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            byte[] result = new byte[data.Length];

            if (key.Length < data.Length)
                throw new ArgumentException("The key used to encrypt is too short");

            for (int i = 0; i < data.Length; i++)
                result[i] = (byte)(data[i] ^ key[i % key.Length]);
            return result;
        }
        public byte[] Encrypt(byte[] data) => Encrypt(data, this.key);
        public static string Encrypt(string data, string key) => GetString(Encrypt(GetBytes(data), GetBytes(key)));
        public string Encrypt(string data) => GetString(Encrypt(GetBytes(data)));

        public static byte[] Decrypt(byte[] data, byte[] key) => Encrypt(data, key);
        public byte[] Decrypt(byte[] data) => Encrypt(data);
        public static string Decrypt(string data, string key) => Encrypt(data, key);
        public string Decrypt(string data) => Encrypt(data);

        public Cryptography(byte[] key) { this.key = key; }
        public Cryptography(string key) { this.key = GetBytes(key); }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OK");
        }
    }
}
