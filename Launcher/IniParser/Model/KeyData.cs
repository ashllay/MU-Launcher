using System;
using System.Collections.Generic;

namespace IniParser.Model
{
	public class KeyData : ICloneable
	{
		public KeyData(string keyName)
		{
			bool flag = string.IsNullOrEmpty(keyName);
			if (flag)
			{
				throw new ArgumentException("key name can not be empty");
			}
			this._comments = new List<string>();
			this._value = string.Empty;
			this._keyName = keyName;
		}

		public KeyData(KeyData ori)
		{
			this._value = ori._value;
			this._keyName = ori._keyName;
			this._comments = new List<string>(ori._comments);
		}

		public List<string> Comments
		{
			get
			{
				return this._comments;
			}
			set
			{
				this._comments = new List<string>(value);
			}
		}

		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		public string KeyName
		{
			get
			{
				return this._keyName;
			}
			set
			{
				bool flag = value != string.Empty;
				if (flag)
				{
					this._keyName = value;
				}
			}
		}

		public object Clone()
		{
			return new KeyData(this);
		}

		private List<string> _comments;

		private string _value;

		private string _keyName;
	}
}
