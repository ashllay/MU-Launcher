// Decompiled with JetBrains decompiler
// Type: Cyclic.Redundancy.Check.CRC
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Cyclic.Redundancy.Check
{
    public sealed class CRC : HashAlgorithm
    {
        public const uint DefaultPolynomial = 3988292384;
        public const uint DefaultSeed = 4294967295;
        private static uint[] defaultTable;
        private readonly uint seed;
        private readonly uint[] table;
        private uint hash;

        public CRC()
          : this(3988292384U, uint.MaxValue)
        {
        }

        public CRC(uint polynomial, uint seed)
        {
            this.table = CRC.InitializeTable(polynomial);
            this.seed = this.hash = seed;
        }

        public override void Initialize()
        {
            this.hash = this.seed;
        }

        protected override void HashCore(byte[] buffer, int start, int length)
        {
            this.hash = CRC.CalculateHash(this.table, this.hash, (IList<byte>)buffer, start, length);
        }

        protected override byte[] HashFinal()
        {
            byte[] bigEndianBytes = CRC.UInt32ToBigEndianBytes(~this.hash);
            this.HashValue = bigEndianBytes;
            return bigEndianBytes;
        }

        public override int HashSize
        {
            get
            {
                return 32;
            }
        }

        public static uint Compute(byte[] buffer)
        {
            return CRC.Compute(uint.MaxValue, buffer);
        }

        public static uint Compute(uint seed, byte[] buffer)
        {
            return CRC.Compute(3988292384U, seed, buffer);
        }

        public static uint Compute(uint polynomial, uint seed, byte[] buffer)
        {
            return ~CRC.CalculateHash(CRC.InitializeTable(polynomial), seed, (IList<byte>)buffer, 0, buffer.Length);
        }

        private static uint[] InitializeTable(uint polynomial)
        {
            if ((int)polynomial == -306674912 && defaultTable != null)
                return CRC.defaultTable;
            uint[] numArray = new uint[256];
            for (int index1 = 0; index1 < 256; ++index1)
            {
                uint num = (uint)index1;
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    if (((int)num & 1) == 1)
                        num = num >> 1 ^ polynomial;
                    else
                        num >>= 1;
                }
                numArray[index1] = num;
            }
            if ((int)polynomial == -306674912)
                defaultTable = numArray;
            return numArray;
        }

        private static uint CalculateHash(uint[] table, uint seed, IList<byte> buffer, int start, int size)
        {
            uint num = seed;
            for (int index = start; index < size - start; ++index)
                num = num >> 8 ^ table[(int)buffer[index] ^ (int)num & (int)byte.MaxValue];
            return num;
        }

        private static byte[] UInt32ToBigEndianBytes(uint uint32)
        {
            byte[] bytes = BitConverter.GetBytes(uint32);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return bytes;
        }
    }
}
