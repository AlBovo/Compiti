namespace BitArray
{
    class BitArray
    {
        private const ulong BIT_VALUE = 8;
        private byte[] bits;
        private ulong n_bits;

        public BitArray(ulong n_bits)
        {
            this.n_bits = n_bits;
            ulong bytes = n_bits / BIT_VALUE;
            if (n_bits % BIT_VALUE != 0)
                ++bytes;
            bits = new byte[bytes];
        }
        
        public byte GetBit(ulong bit_index)
        {
            if (bit_index < 0)
                throw new ArgumentOutOfRangeException("The index of the bit is out of range");
            if (bit_index >= n_bits)
                return 0;

            byte mask = (byte)(1 << (int)(bit_index % BIT_VALUE));
            return (byte)((bits[bit_index / BIT_VALUE] & mask) >> (int)bit_index);
        }
        
        public void SetBit(ulong bit_index, byte value)
        {
            if (bit_index < 0)
                throw new ArgumentOutOfRangeException("The index of the bit is out of range");
            if (bit_index >= n_bits)
                return;

            if (value == 1)
            {
                byte mask = (byte)((value & 1) << (int)(bit_index % BIT_VALUE));
                bits[bit_index / BIT_VALUE] |= mask;
            }
            else
            {
                byte mask = (byte)~(1 << (int)(bit_index % BIT_VALUE));
                bits[bit_index / BIT_VALUE] &= mask;
            }
        }

        public static BitArray operator |(BitArray a, BitArray b)
        {
            ulong n_bits = Math.Max(a.n_bits, b.n_bits);
            BitArray result = new BitArray(n_bits);
            for (ulong i = 0; i < n_bits; i++)
            {
                byte r = a[i];
                byte s = b[i];
                result[i] = (byte)(a[i] | b[i]);
            }
            return result;
        }

        public static BitArray operator &(BitArray a, BitArray b)
        {
            ulong n_bits = Math.Max(a.n_bits, b.n_bits);
            BitArray result = new BitArray(n_bits);
            for (ulong i = 0; i < n_bits; i++)
                result[i] = (byte)(a[i] & b[i]);
            return result;
        }

        public static BitArray operator ^(BitArray a, BitArray b)
        {
            ulong n_bits = Math.Max(a.n_bits, b.n_bits);
            BitArray result = new BitArray(n_bits);
            for (ulong i = 0; i < n_bits; i++)
                result[i] = (byte)(a[i] ^ b[i]);
            return result;
        }

        public static BitArray operator ~(BitArray a)
        {
            ulong n_bits = a.n_bits;
            BitArray result = new BitArray(n_bits);
            for (ulong i = 0; i < n_bits; i++)
            {
                result[i] = (byte)(a[i] == 0 ? 1 : 0);
            }
            return result;
        }

        public static implicit operator ulong (BitArray bitArray)
        {
            ulong result = 0;
            for (ulong i = 0; i < bitArray.n_bits; i++)
            {
                var r = bitArray[i];
                result |= (byte)(bitArray[i] << (int)i);
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            for (ulong i = 0; i < n_bits; i++)
                result = (this[i] == 1 ? '1' : '0') + result;
            return result;
        }

        public byte this[ulong bit_index] { get => GetBit(bit_index); set => SetBit(bit_index, value); }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BitArray a = new BitArray(8);
            BitArray b = new BitArray(8);
            a[0] = 1;
            a[2] = 1;
            b[1] = 1;
            Console.WriteLine((a ^ b).ToString());
        }
    }
}
