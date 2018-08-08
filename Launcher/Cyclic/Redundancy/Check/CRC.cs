using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Cyclic.Redundancy.Check
{
	public sealed class CRC : HashAlgorithm
	{
		public CRC() : this(3988292384u, uint.MaxValue)
		{
		}

		public CRC(uint polynomial, uint seed)
		{
			this.table = CRC.InitializeTable(polynomial);
			this.hash = seed;
			this.seed = seed;
		}

		public override void Initialize()
		{
			this.hash = this.seed;
		}

		protected override void HashCore(byte[] buffer, int start, int length)
		{
			this.hash = CRC.CalculateHash(this.table, this.hash, buffer, start, length);
		}

		protected override byte[] HashFinal()
		{
			byte[] array = CRC.UInt32ToBigEndianBytes(~this.hash);
			this.HashValue = array;
			return array;
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
			return CRC.Compute(3988292384u, seed, buffer);
		}

		public static uint Compute(uint polynomial, uint seed, byte[] buffer)
		{
			return ~CRC.CalculateHash(CRC.InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
		}

		private static uint[] InitializeTable(uint polynomial)
		{
			bool flag = polynomial == 3988292384u && CRC.defaultTable != null;
			uint[] result;
			if (flag)
			{
				result = CRC.defaultTable;
			}
			else
			{
				uint[] array = new uint[256];
				for (int i = 0; i < 256; i++)
				{
					uint num = (uint)i;
					for (int j = 0; j < 8; j++)
					{
						bool flag2 = (num & 1u) == 1u;
						if (flag2)
						{
							num = (num >> 1 ^ polynomial);
						}
						else
						{
							num >>= 1;
						}
					}
					array[i] = num;
				}
				bool flag3 = polynomial == 3988292384u;
				if (flag3)
				{
					CRC.defaultTable = array;
				}
				result = array;
			}
			return result;
		}

		private static uint CalculateHash(uint[] table, uint seed, IList<byte> buffer, int start, int size)
		{
			uint num = seed;
			for (int i = start; i < size - start; i++)
			{
				num = (num >> 8 ^ table[(int)((uint)buffer[i] ^ (num & 255u))]);
			}
			return num;
		}

		private static byte[] UInt32ToBigEndianBytes(uint uint32)
		{
			byte[] bytes = BitConverter.GetBytes(uint32);
			bool isLittleEndian = BitConverter.IsLittleEndian;
			if (isLittleEndian)
			{
				Array.Reverse(bytes);
			}
			return bytes;
		}

		public const uint DefaultPolynomial = 3988292384u;

		public const uint DefaultSeed = 4294967295u;

		private static uint[] defaultTable;

		private readonly uint seed;

		private readonly uint[] table;

		private uint hash;
	}
}
