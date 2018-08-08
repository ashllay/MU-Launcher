using System;
using System.Collections.Generic;
using System.Text;
using IniParser.Model.Configuration;

namespace IniParser.Model.Formatting
{
	public class DefaultIniDataFormatter : IIniDataFormatter
	{
		public DefaultIniDataFormatter() : this(new IniParserConfiguration())
		{
		}

		public DefaultIniDataFormatter(IniParserConfiguration configuration)
		{
			bool flag = configuration == null;
			if (flag)
			{
				throw new ArgumentNullException("configuration");
			}
			this.Configuration = configuration;
		}

		public virtual string IniDataToString(IniData iniData)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool allowKeysWithoutSection = this.Configuration.AllowKeysWithoutSection;
			if (allowKeysWithoutSection)
			{
				this.WriteKeyValueData(iniData.Global, stringBuilder);
			}
			foreach (SectionData section in iniData.Sections)
			{
				this.WriteSection(section, stringBuilder);
			}
			return stringBuilder.ToString();
		}

		public IniParserConfiguration Configuration
		{
			get
			{
				return this._configuration;
			}
			set
			{
				this._configuration = value.Clone();
			}
		}

		private void WriteSection(SectionData section, StringBuilder sb)
		{
			bool flag = sb.Length > 0;
			if (flag)
			{
				sb.Append(this.Configuration.NewLineStr);
			}
			sb.Append(string.Format("{0}{1}{2}{3}", new object[]
			{
				this.Configuration.SectionStartChar,
				section.SectionName,
				this.Configuration.SectionEndChar,
				this.Configuration.NewLineStr
			}));
			this.WriteKeyValueData(section.Keys, sb);
		}

		private void WriteKeyValueData(KeyDataCollection keyDataCollection, StringBuilder sb)
		{
			foreach (KeyData keyData in keyDataCollection)
			{
				bool flag = keyData.Comments.Count > 0;
				if (flag)
				{
					sb.Append(this.Configuration.NewLineStr);
				}
				this.WriteComments(keyData.Comments, sb);
				sb.Append(string.Format("{0}{3}{1}{3}{2}{4}", new object[]
				{
					keyData.KeyName,
					this.Configuration.KeyValueAssigmentChar,
					keyData.Value,
					this.Configuration.AssigmentSpacer,
					this.Configuration.NewLineStr
				}));
			}
		}

		private void WriteComments(List<string> comments, StringBuilder sb)
		{
			foreach (string arg in comments)
			{
				sb.Append(string.Format("{0}{1}{2}", this.Configuration.CommentString, arg, this.Configuration.NewLineStr));
			}
		}

		private IniParserConfiguration _configuration;
	}
}
