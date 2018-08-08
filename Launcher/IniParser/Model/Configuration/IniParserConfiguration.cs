using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace IniParser.Model.Configuration
{
	public class IniParserConfiguration : ICloneable
	{
		public IniParserConfiguration()
		{
			this.CommentString = ";";
			this.SectionStartChar = '[';
			this.SectionEndChar = ']';
			this.KeyValueAssigmentChar = '=';
			this.AssigmentSpacer = " ";
			this.NewLineStr = Environment.NewLine;
			this.ConcatenateDuplicateKeys = false;
			this.AllowKeysWithoutSection = true;
			this.AllowDuplicateKeys = false;
			this.AllowDuplicateSections = false;
			this.AllowCreateSectionsOnFly = true;
			this.ThrowExceptionsOnError = true;
			this.SkipInvalidLines = false;
		}

		public IniParserConfiguration(IniParserConfiguration ori)
		{
			this.AllowDuplicateKeys = ori.AllowDuplicateKeys;
			this.OverrideDuplicateKeys = ori.OverrideDuplicateKeys;
			this.AllowDuplicateSections = ori.AllowDuplicateSections;
			this.AllowKeysWithoutSection = ori.AllowKeysWithoutSection;
			this.AllowCreateSectionsOnFly = ori.AllowCreateSectionsOnFly;
			this.SectionStartChar = ori.SectionStartChar;
			this.SectionEndChar = ori.SectionEndChar;
			this.CommentString = ori.CommentString;
			this.ThrowExceptionsOnError = ori.ThrowExceptionsOnError;
		}

		public Regex CommentRegex { get; set; }

		public Regex SectionRegex { get; set; }

		public char SectionStartChar
		{
			get
			{
				return this._sectionStartChar;
			}
			set
			{
				this._sectionStartChar = value;
				this.RecreateSectionRegex(this._sectionStartChar);
			}
		}

		public char SectionEndChar
		{
			get
			{
				return this._sectionEndChar;
			}
			set
			{
				this._sectionEndChar = value;
				this.RecreateSectionRegex(this._sectionEndChar);
			}
		}

		public bool CaseInsensitive { get; set; }

		[Obsolete("Please use the CommentString property")]
		public char CommentChar
		{
			get
			{
				return this.CommentString[0];
			}
			set
			{
				this.CommentString = value.ToString();
			}
		}

		public string CommentString
		{
			get
			{
				return this._commentString ?? string.Empty;
			}
			set
			{
				foreach (char c in "[]\\^$.|?*+()")
				{
					value = value.Replace(new string(c, 1), "\\" + c.ToString());
				}
				this.CommentRegex = new Regex(string.Format("^{0}(.*)", value));
				this._commentString = value;
			}
		}

		public string NewLineStr { get; set; }

		public char KeyValueAssigmentChar { get; set; }

		public string AssigmentSpacer { get; set; }

		public bool AllowKeysWithoutSection { get; set; }

		public bool AllowDuplicateKeys { get; set; }

		public bool OverrideDuplicateKeys { get; set; }

		public bool ConcatenateDuplicateKeys { get; set; }

		public bool ThrowExceptionsOnError { get; set; }

		public bool AllowDuplicateSections { get; set; }

		public bool AllowCreateSectionsOnFly { get; set; }

		public bool SkipInvalidLines { get; set; }

		private void RecreateSectionRegex(char value)
		{
			bool flag = char.IsControl(value) || char.IsWhiteSpace(value) || this.CommentString.Contains(new string(new char[]
			{
				value
			})) || value == this.KeyValueAssigmentChar;
			if (flag)
			{
				throw new Exception(string.Format("Invalid character for section delimiter: '{0}", value));
			}
			string text = "^(\\s*?)";
			bool flag2 = "[]\\^$.|?*+()".Contains(new string(this._sectionStartChar, 1));
			if (flag2)
			{
				text = text + "\\" + this._sectionStartChar.ToString();
			}
			else
			{
				text += this._sectionStartChar.ToString();
			}
			text += "{1}\\s*[\\p{L}\\p{P}\\p{M}_\\\"\\'\\{\\}\\#\\+\\;\\*\\%\\(\\)\\=\\?\\&\\$\\,\\:\\/\\.\\-\\w\\d\\s\\\\\\~]+\\s*";
			bool flag3 = "[]\\^$.|?*+()".Contains(new string(this._sectionEndChar, 1));
			if (flag3)
			{
				text = text + "\\" + this._sectionEndChar.ToString();
			}
			else
			{
				text += this._sectionEndChar.ToString();
			}
			text += "(\\s*?)$";
			this.SectionRegex = new Regex(text);
		}

		public override int GetHashCode()
		{
			int num = 27;
			foreach (PropertyInfo propertyInfo in base.GetType().GetProperties())
			{
				num = num * 7 + propertyInfo.GetValue(this, null).GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			IniParserConfiguration iniParserConfiguration = obj as IniParserConfiguration;
			bool flag = iniParserConfiguration == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Type type = base.GetType();
				try
				{
					foreach (PropertyInfo propertyInfo in type.GetProperties())
					{
						bool flag2 = propertyInfo.GetValue(iniParserConfiguration, null).Equals(propertyInfo.GetValue(this, null));
						if (flag2)
						{
							return false;
						}
					}
				}
				catch
				{
					return false;
				}
				result = true;
			}
			return result;
		}

		public IniParserConfiguration Clone()
		{
			return base.MemberwiseClone() as IniParserConfiguration;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		private char _sectionStartChar;

		private char _sectionEndChar;

		private string _commentString;

		protected const string _strCommentRegex = "^{0}(.*)";

		protected const string _strSectionRegexStart = "^(\\s*?)";

		protected const string _strSectionRegexMiddle = "{1}\\s*[\\p{L}\\p{P}\\p{M}_\\\"\\'\\{\\}\\#\\+\\;\\*\\%\\(\\)\\=\\?\\&\\$\\,\\:\\/\\.\\-\\w\\d\\s\\\\\\~]+\\s*";

		protected const string _strSectionRegexEnd = "(\\s*?)$";

		protected const string _strKeyRegex = "^(\\s*[_\\.\\d\\w]*\\s*)";

		protected const string _strValueRegex = "([\\s\\d\\w\\W\\.]*)$";

		protected const string _strSpecialRegexChars = "[]\\^$.|?*+()";
	}
}
